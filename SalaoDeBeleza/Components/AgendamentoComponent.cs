using Microsoft.EntityFrameworkCore;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.DataBase;

namespace SalaoDeBeleza.Services
{
    public class AgendamentoComponent
    {
        private readonly DBContextInMemory dbContext;
        public AgendamentoComponent(DBContextInMemory db)
        {
            dbContext = db;
        }

        public Agendamento Insert(Agendamento vo)
        {
            /*if (dto.Description == null)
            {
                throw new BadRequestException("Dados inválidos");
            }
            if (dto.Barcodetype == null)
            {
                throw new BadRequestException("Dados inválidos");
            }
            if (dto.Barcodetype == null)
            {
                throw new BadRequestException("Dados inválidos");
            }*/

            //var agendamento = _mapper.Map<TbProduct>(dto);

            dbContext.Agendamentos.Add(vo);
            dbContext.SaveChanges();    

            /*_stockLogService.InsertStockLog(new StockLogDTO
            {
                Productid = product.Id,
                Qty = product.Stock,
                Createdat = DateTime.Now
            });*/

            return vo;
        }
    }
}
