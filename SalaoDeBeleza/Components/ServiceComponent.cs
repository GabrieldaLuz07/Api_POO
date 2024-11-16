using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.DataBase;
using SalaoDeBeleza.DTOs;
using SalaoDeBeleza.Mappings;
using SalaoDeBeleza.Repositories;
using SalaoDeBeleza.Validate;
using System.ComponentModel;
using System.Reflection;

namespace SalaoDeBeleza.Components
{
    public class ServiceComponent
    {
        private ServiceRepository repository;
        private readonly IMapper mapper;
        private ServiceValidate validator;
        private CustomerComponent customerComponent;
        private ProfessionalComponent professionalComponent;

        public ServiceComponent(DBContextInMemory db)
        {
            // Inicializo as instâncias que vou utilizar
            repository = new ServiceRepository(db);
            validator = new ServiceValidate();
            customerComponent = new CustomerComponent(db);
            professionalComponent = new ProfessionalComponent(db);

            // Faço a instância do mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceMapper>();
            });
            // Validação do mapper
            config.AssertConfigurationIsValid();
            mapper = config.CreateMapper();
        }

        // Função para verificar se existe um registro com o id informado, para não ter que buscar toda vez e verificar se esta diferente de null
        public bool ServiceExists(int id)
        {
            return repository.VerifyService(id);
        }

        // Função retornando uma lista de DTOs serviços.
        // Primeiramente eu busco a lista de serviços, e depois faço um Foreach passando todos os dados da classe para um DTO, e depois adicionado
        // o DTO a uma lista para exibição
        // Esse DTO foi criado especificamente para exibir os registros de forma mais limpa e clara.
        public List<ServiceDisplayDTO> GetAll()
        {
            List<ServiceDisplayDTO> displays = new List<ServiceDisplayDTO>();

            List<Service> services = repository.GetAllServices();
            foreach (Service service in services)
            {
                displays.Add(GetServiceDisplayById(service.Id));
            }
            return displays;
        }

        // Buscando pelo id, validando caso o id seja menor ou igual a 0, e caso não encontre o serviço pelo id informado
        public Service GetById(int id)
        {
            if (id <= 0)
                throw new Exception("Serviço inválido!");

            if (!ServiceExists(id))
                throw new Exception("Serviço não encontrado!");

            Service service = repository.GetServiceById(id);
            return service;
        }

        // Função para exibir o serviço quando buscado pelo id. Ela converte a classe em um DTO de exibição.
        public ServiceDisplayDTO GetServiceDisplayById(int id)
        {
            // Validações
            if (id <= 0)
                throw new Exception("Serviço inválido!");

            if (!ServiceExists(id))
                throw new Exception("Serviço não encontrado!");

            // Crio as instâncias das classes utilizadas
            Service service = repository.GetServiceById(id);
            Customer customer = customerComponent.GetById(service.IdCustomer);
            Professional professional = professionalComponent.GetById(service.IdProfessional);

            // Instâncio um novo DTO, e seto nele os dados da classe, para exibir em um formato mais claro, e não apenas numeros.
            ServiceDisplayDTO display = new ServiceDisplayDTO();
            display.Id = service.Id;
            display.Customer = customer;
            display.Professional = professional;
            display.Price = service.Price != 0 ? "R$" + service.Price : "O Serviço ainda não foi pago";
            display.Duration = service.Duration != 0 ? service.Duration + " minutos" : "O serviço ainda não foi realizado";

            // Usado para exibir a descrição do Enum ao invés do seu número
            FieldInfo info = service.Type.GetType().GetField(service.Type.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(info, typeof(DescriptionAttribute)) as DescriptionAttribute;
            display.Type = attribute.Description;

            // Usado para exibir a descrição do Enum ao invés do seu número
            FieldInfo info2 = service.Status.GetType().GetField(service.Status.ToString());
            DescriptionAttribute attribute2 = Attribute.GetCustomAttribute(info2, typeof(DescriptionAttribute)) as DescriptionAttribute;
            display.Status = attribute2.Description;

            return display;
        }

        // Insert, validando antes de registrar.
        public void Insert(ServiceDTO dto)
        {
            validator.ValidateService(dto);

            Customer customer = customerComponent.GetById(dto.IdCustomer);

            // Antes de inserir, eu verifico se o profissional está disponível para o serviço
            Professional professional = professionalComponent.GetById(dto.IdProfessional);
            if (!professional.Available)
            {
                throw new Exception("O profissional não está disponível!");
            }

            // Altero a propriedade "Disponível" do profissional para false, já que agora ele esta em um serviço
            professionalComponent.SetProfessionalAvailabilityFalse(dto.IdProfessional);

            //Instâncio um novo serviço e depois cadastro ele.
            Service service = new Service();
            service.IdCustomer = customer.Id;
            service.IdProfessional = professional.Id;
            service.Type = dto.Type;
            service.Status = Enums.ServiceStatus.OptionZero; // Agendado
            repository.AddService(service);
        }

        // Update, validando antes de atualizar e buscando o serviço.
        // Esse update foi feito pensando na necessidade de alterar o serviço depois de cadastrado, caso alguma informação
        // tenha sido cadastrada errada
        public void Update(int id, ServiceUpdateDTO dto)
        {
            validator.ValidateServiceUpdate(dto);

            // Busco as classes utilizadas para garantir que existem
            Customer customer = customerComponent.GetById(dto.IdCustomer);
            Professional professional = professionalComponent.GetById(dto.IdProfessional);

            //Instâncio o serviço e depois atualizo ele.
            Service service = GetById(id);
            service.IdCustomer = customer.Id;
            service.IdProfessional = professional.Id;
            service.Type = dto.Type;
            service.Price = dto.Price;

            repository.UpdateService(service);
        }

        // Update, validando antes de atualizar e buscando o serviço.
        // Esse update foi feito pensando na hora de finalizar o serviço, ele foi realizado já e agora é necessário apenas
        // informar o preço e duração
        public void Finish(int id, ServiceFinishDTO dto)
        {
            validator.ValidateServiceFinish(dto);

            //Instâncio o serviço e depois atualizo ele.
            Service service = GetById(id);
            service.Price = dto.Price;
            service.Duration = dto.Duration;
            service.Status = Enums.ServiceStatus.OptionOne; // Finalizado

            repository.UpdateService(service);

            // Como o serviço foi finalizado, agora posso setar a propriedade "Disponível" do profissional para true novamente
            professionalComponent.SetProfessionalAvailabilityTrue(service.IdProfessional);
        }

        // Delete, buscando o serviço antes de excluir
        public void Delete(int id)
        {
            Service service = GetById(id);
            repository.DeleteService(service);
        }
    }
}
