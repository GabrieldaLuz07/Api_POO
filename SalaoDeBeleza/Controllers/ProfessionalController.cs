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
    public ProfessionalController(DBContextInMemory db)
    {
        professionalComponent = new ProfessionalComponent(db);
    }

    // Buscar todos os profissionais
    [HttpGet]
    public List<Professional> GetProfessionals()
    {
        return professionalComponent.GetAll();
    }

    // Buscar todos os profissionais
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
        try
        {
            professionalComponent.Insert(dto);
            return Ok("Cliente cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Atualizar um profissional existente
    [HttpPut("{id}")]
    public IActionResult UpdateProfessionals(int id, [FromBody] ProfessionalDTO dto)
    {
        try
        {
            professionalComponent.Update(id, dto);
            return Ok("Cliente atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Excluir um profissional
    [HttpDelete("{id}")]
    public IActionResult DeleteProfessionals(int id)
    {
        try
        {
            professionalComponent.Delete(id);
            return Ok("Cliente excluído com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
