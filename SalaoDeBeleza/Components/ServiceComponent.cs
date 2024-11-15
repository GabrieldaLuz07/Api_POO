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

        // Função para verificar se existe um registro com o id informado
        public bool ServiceExists(int id)
        {
            return repository.VerifyService(id);
        }

        // Método GetAll retornando direto a lista de serviços
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

        public ServiceDisplayDTO GetServiceDisplayById(int id)
        {
            if (id <= 0)
                throw new Exception("Serviço inválido!");

            if (!ServiceExists(id))
                throw new Exception("Serviço não encontrado!");

            Service service = repository.GetServiceById(id);
            Customer customer = customerComponent.GetById(service.IdCustomer);
            Professional professional = professionalComponent.GetById(service.IdProfessional);

            ServiceDisplayDTO display = new ServiceDisplayDTO();
            display.Customer = customer;
            display.Professional = professional;
            display.Price = service.Price != 0 ? "R$" + service.Price : "O Serviço ainda não foi pago";
            display.Duration = service.Duration != 0 ? service.Duration + " minutos" : "O serviço ainda não foi realizado";

            FieldInfo info = service.Type.GetType().GetField(service.Type.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(info, typeof(DescriptionAttribute)) as DescriptionAttribute;
            display.Type = attribute.Description;

            FieldInfo info2 = service.Status.GetType().GetField(service.Status.ToString());
            DescriptionAttribute attribute2 = Attribute.GetCustomAttribute(info2, typeof(DescriptionAttribute)) as DescriptionAttribute;
            display.Status = attribute2.Description;

            return display;
        }

        // Insert, validando antes de registrar, mapeando para a classe e depois adicionando.
        public ServiceDTO Insert(ServiceDTO dto)
        {
            validator.ValidateService(dto);

            Customer customer = customerComponent.GetById(dto.IdCustomer);
            Professional professional = professionalComponent.GetById(dto.IdProfessional);
            if (!professional.Available)
            {
                throw new Exception("O profissional não está disponível!");
            }
            professionalComponent.SetProfessionalAvailabilityFalse(dto.IdProfessional);

            Service service = new Service();
            service.IdCustomer = customer.Id;
            service.IdProfessional = professional.Id;
            service.Type = dto.Type;
            service.Status = Enums.ServiceStatus.OptionZero; // Agendado
            repository.AddService(service);
            return dto;
        }

        // Update, validando antes de atualizar, buscando o serviço, mapeando para a classe e depois atualizando.
        public void Update(int id, ServiceUpdateDTO dto)
        {
            validator.ValidateServiceUpdate(dto);
            Customer customer = customerComponent.GetById(dto.IdCustomer);
            Professional professional = professionalComponent.GetById(dto.IdProfessional);

            Service service = GetById(id);
            service.IdCustomer = customer.Id;
            service.IdProfessional = professional.Id;
            service.Type = dto.Type;
            service.Price = dto.Price;
            service.Duration = dto.Duration;

            repository.UpdateService(service);
        }

        // Update, validando antes de atualizar, buscando o serviço, mapeando para a classe e depois atualizando.
        public void Finish(int id, ServiceFinishDTO dto)
        {
            validator.ValidateServiceFinish(dto);

            Service service = GetById(id);
            service = mapper.Map<Service>(dto);
            service.Status = Enums.ServiceStatus.OptionOne; // Finalizado

            repository.UpdateService(service);

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
