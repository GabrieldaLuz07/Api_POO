using Microsoft.EntityFrameworkCore;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components.DTOs;
using SalaoDeBeleza.Components.Exceptions;
using SalaoDeBeleza.DataBase;
using AutoMapper;
using SalaoDeBeleza.DataBase.Modelos;
using SalaoDeBeleza.Components.Mappings;

namespace SalaoDeBeleza.Components
{
    public class SchedulingComponent
    {
        private readonly DBContextInMemory dbContext;
        private readonly IMapper mapper;
        public SchedulingComponent(DBContextInMemory db)
        {
            dbContext = db;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SchedulingMapper>();
            });
            mapper = config.CreateMapper();
        }

        public List<Scheduling> getAgendamentos()
        {
            return dbContext.Scheduling.ToList();
        }

        public SchedulingDTO Insert(SchedulingDTO dto)
        {
            Scheduling scheduling = mapper.Map<Scheduling>(dto);
            dbContext.Scheduling.Add(scheduling);
            dbContext.SaveChanges();    
            return dto;
        }
    
    }
}
