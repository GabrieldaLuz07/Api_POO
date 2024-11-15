using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components;
using SalaoDeBeleza.DataBase;
using SalaoDeBeleza.DTOs;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private ServiceComponent serviceComponent;
    public ServiceController(DBContextInMemory db)
    {
        serviceComponent = new ServiceComponent(db);
    }

    // Buscar todos os serviços
    [HttpGet]
    public List<ServiceDisplayDTO> GetServices()
    {
        return serviceComponent.GetAll();
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
        try
        {
            serviceComponent.Insert(dto);
            return Ok("Serviço cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Atualizar um serviço existente
    [HttpPut("{id}")]
    public IActionResult UpdateService(int id, [FromBody] ServiceUpdateDTO dto)
    {
        try
        {
            serviceComponent.Update(id, dto);
            return Ok("Serviço atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Finalizar um serviço existente
    [HttpPut("finish/{id}")]
    public IActionResult FinishService(int id, [FromBody] ServiceFinishDTO dto)
    {
        try
        {
            serviceComponent.Finish(id, dto);
            return Ok("Serviço finalizado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Excluir um serviço
    [HttpDelete("{id}")]
    public IActionResult DeleteService(int id)
    {
        try
        {
            serviceComponent.Delete(id);
            return Ok("Serviço excluído com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
