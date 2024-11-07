using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components.DTOs;
using SalaoDeBeleza.Components.Mappings;
using SalaoDeBeleza.DataBase;

namespace SalaoDeBeleza.Components
{
    public class ProfessionalComponent
    {
        private readonly DBContextInMemory dbContext;
        private readonly IMapper mapper;
        public ProfessionalComponent(DBContextInMemory db)
        {
            dbContext = db;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProfessionalMapper>();
            });
            mapper = config.CreateMapper();
        }

        public List<Professional> getProfessionals()
        {
            return dbContext.Professional.ToList();
        }

        public ProfessionalDTO Insert(ProfessionalDTO dto)
        {
            Professional professional = mapper.Map<Professional>(dto);
            dbContext.Professional.Add(professional);
            dbContext.SaveChanges();
            return dto;
        }
    }
}
