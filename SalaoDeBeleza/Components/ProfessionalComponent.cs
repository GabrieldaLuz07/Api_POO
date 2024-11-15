using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Exceptions;
using SalaoDeBeleza.DataBase;
using SalaoDeBeleza.DTOs;
using SalaoDeBeleza.Mappings;
using SalaoDeBeleza.Repositories;
using SalaoDeBeleza.Validate;

namespace SalaoDeBeleza.Components
{
    public class ProfessionalComponent
    {
        private ProfessionalRepository repository;
        private readonly IMapper mapper;
        private ProfessionalValidate validator;

        // Aqui eu crio as instâncias e o mapper
        public ProfessionalComponent(DBContextInMemory db)
        {
            repository = new ProfessionalRepository(db);
            validator = new ProfessionalValidate();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProfessionalMapper>();
            });
            // Validação do mapper
            config.AssertConfigurationIsValid();
            mapper = config.CreateMapper();
        }

        // Função para verificar se existe um registro com o id informado
        public bool ProfessionalExists(int id)
        {
            return repository.VerifyProfessional(id);
        }

        // Método GetAll retornando direto a lista de profissionais
        public List<Professional> GetAll()
        {
            return repository.GetAllProfessionals();
        }

        // Buscando pelo id, validando caso o id seja menor ou igual a 0, e caso não encontre o profissional pelo id informado
        public Professional GetById(int id)
        {
            if (id <= 0)
                throw new Exception("Profissional inválido!");

            return ProfessionalExists(id) ? repository.GetProfessionalById(id) : throw new Exception("Profissional não encontrado!");
        }

        public List<Professional> GetAvaibleProfessionals()
        {
            return repository.GetAvaibleProfessionals();
        }

        // Insert, validando antes de registrar, mapeando para a classe e depois adicionando.
        public ProfessionalDTO Insert(ProfessionalDTO dto)
        {
            validator.ValidateProfessional(dto);

            Professional professional = new Professional();
            professional = mapper.Map<Professional>(dto);
            professional.Available = true;
            repository.AddProfessional(professional);
            return dto;
        }

        // Update, validando antes de atualizar, buscando o profissional, mapeando para a classe e depois atualizando.
        public void Update(int id, ProfessionalDTO dto)
        {
            validator.ValidateProfessional(dto);

            Professional professional = repository.GetProfessionalById(id);
            professional.Name = dto.Name;
            professional.Telephone = dto.Telephone;

            repository.UpdateProfessional(professional);
        }

        public void SetProfessionalAvailabilityFalse(int idProfessional)
        {
            Professional professional = GetById(idProfessional);
            professional.Available = false;
            repository.UpdateProfessional(professional);
        }

        public void SetProfessionalAvailabilityTrue(int idProfessional)
        {
            Professional professional = GetById(idProfessional);
            professional.Available = true;
            repository.UpdateProfessional(professional);
        }

        // Delete, buscando o profissional antes de excluir
        public void Delete(int id)
        {
            Professional professional = repository.GetProfessionalById(id);
            repository.DeleteProfessional(professional);
        }
    }
}
