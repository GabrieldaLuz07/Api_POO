using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components;
using SalaoDeBeleza.DataBase;
using SalaoDeBeleza.DTOs;
using SalaoDeBeleza.Enums;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private ServiceComponent serviceComponent;
    private ILogger<ServiceController> logger;
    public ServiceController(DBContextInMemory db, ILogger<ServiceController> iLogger)
    {
        serviceComponent = new ServiceComponent(db);
        logger = iLogger;
    }

    // Buscar todos os serviços
    [HttpGet]
    public List<ServiceDisplayDTO> GetServices()
    {
        return serviceComponent.GetAll();
    }

    // Buscar todos os serviços oferecidos pelo salão
    [HttpGet("avaible")]
    public List<string> GetOferredServices()
    {
        return ServiceTypeHelper.GetDescriptions<ServiceType>();
    }

    // Buscar um serviço específico pelo id
    [HttpGet("{id}")]
    public IActionResult GetServiceById(int id)
    {
        try
        {
            return Ok(serviceComponent.GetServiceDisplayById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Cadastrar um serviço
    [HttpPost]
    public IActionResult InsertService([FromBody] ServiceDTO dto)
    {
        logger.LogInformation("Post Serviço");
        try
        {
            serviceComponent.Insert(dto);

            logger.LogInformation("Serviço cadastrado com sucesso.");

            return Ok("Serviço cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            logger.LogInformation("Serviço não cadastrado. Motivo: " + ex.Message);
            return BadRequest(ex.Message);
        }
    }

    // Atualizar um serviço existente
    [HttpPut("{id}")]
    public IActionResult UpdateService(int id, [FromBody] ServiceUpdateDTO dto)
    {
        logger.LogInformation("Put Serviço");
        try
        {
            serviceComponent.Update(id, dto);

            logger.LogInformation("Serviço atualizado com sucesso.");

            return Ok("Serviço atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            logger.LogInformation("Serviço não atualizado. Motivo: " + ex.Message);
            return BadRequest(ex.Message);
        }
    }

    // Finalizar um serviço existente
    [HttpPut("finish/{id}")]
    public IActionResult FinishService(int id, [FromBody] ServiceFinishDTO dto)
    {
        logger.LogInformation("Finish Serviço");
        try
        {
            serviceComponent.Finish(id, dto);

            logger.LogInformation("Serviço finalizado com sucesso.");

            return Ok("Serviço finalizado com sucesso!");
        }
        catch (Exception ex)
        {
            logger.LogInformation("Serviço não finalizado. Motivo: " + ex.Message);
            return BadRequest(ex.Message);
        }
    }

    // Excluir um serviço
    [HttpDelete("{id}")]
    public IActionResult DeleteService(int id)
    {
        logger.LogInformation("Delete Serviço");
        try
        {
            serviceComponent.Delete(id);

            logger.LogInformation("Serviço excluído com sucesso.");

            return Ok("Serviço excluído com sucesso!");
        }
        catch (Exception ex)
        {
            logger.LogInformation("Serviço não excluido. Motivo: " + ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
