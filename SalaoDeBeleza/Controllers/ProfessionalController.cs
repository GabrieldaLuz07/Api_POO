using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components;
using SalaoDeBeleza.DataBase;
using SalaoDeBeleza.DTOs;

[Route("api/[controller]")]
[ApiController]
public class ProfessionalController : ControllerBase
{
    private ProfessionalComponent professionalComponent;
    private ILogger<ServiceController> logger;
    public ProfessionalController(DBContextInMemory db, ILogger<ServiceController> iLogger)
    {
        professionalComponent = new ProfessionalComponent(db);
        logger = iLogger;
    }

    // Buscar todos os profissionais
    [HttpGet]
    public List<Professional> GetProfessionals()
    {
        return professionalComponent.GetAll();
    }

    // Buscar todos os profissionais disponíveis
    [HttpGet("avaible")]
    public List<Professional> GetAvaibleProfessionals()
    {
        return professionalComponent.GetAvaibleProfessionals();
    }

    // Buscar um profissional específico pelo id
    [HttpGet("{id}")]
    public Professional GetProfessionalById(int id)
    {
        return professionalComponent.GetById(id);
    }

    // Cadastrar um profissional
    [HttpPost]
    public IActionResult InsertProfessionals([FromBody] ProfessionalDTO dto)
    {
        logger.LogInformation("Post Profissional");
        try
        {
            professionalComponent.Insert(dto);

            logger.LogInformation("Profissional cadastrado com sucesso.");

            return Ok("Profissional cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            logger.LogInformation("Profissional não cadastrado. Motivo: " + ex.Message);
            return BadRequest(ex.Message);
        }
    }

    // Atualizar um profissional existente
    [HttpPut("{id}")]
    public IActionResult UpdateProfessionals(int id, [FromBody] ProfessionalDTO dto)
    {
        logger.LogInformation("Put Profissional");
        try
        {
            professionalComponent.Update(id, dto);

            logger.LogInformation("Profissional atualizado com sucesso.");

            return Ok("Profissional atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            logger.LogInformation("Profissional não atualizado. Motivo: " + ex.Message);
            return BadRequest(ex.Message);
        }
    }

    // Excluir um profissional
    [HttpDelete("{id}")]
    public IActionResult DeleteProfessionals(int id)
    {
        logger.LogInformation("Profissional Service");
        try
        {
            professionalComponent.Delete(id);

            logger.LogInformation("Profissional excluído com sucesso.");

            return Ok("Profissional excluído com sucesso!");
        }
        catch (Exception ex)
        {
            logger.LogInformation("Profissional não excluido. Motivo: " + ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
