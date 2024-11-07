using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components.DTOs;
using SalaoDeBeleza.Components;

[Route("api/[controller]")]
[ApiController]
public class ProfessionalController : ControllerBase
{
    private ProfessionalComponent professionalComponent;
    public ProfessionalController(ProfessionalComponent component)
    {
        professionalComponent = component;
    }


    [HttpGet]
    public List<Professional> getProfessionals()
    {
        return professionalComponent.getProfessionals();
    }

    [HttpPost]
    public void InsertProfessionals([FromBody] ProfessionalDTO dto)
    {
        professionalComponent.Insert(dto);
    }

    /*
    [HttpPut("{id}")]
    public IActionResult AtualizarProfissional(int id, [FromBody] Profissional profissional)
    {
        var profissionalExistente = Profissionais.FirstOrDefault(p => p.Id == id);
        if (profissionalExistente == null)
            return NotFound();

        profissionalExistente.Nome = profissional.Nome;
        profissionalExistente.Especializacao = profissional.Especializacao;
        profissionalExistente.Disponivel = profissional.Disponivel;

        return Ok(profissionalExistente);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarProfissional(int id)
    {
        var profissional = Profissionais.FirstOrDefault(p => p.Id == id);
        if (profissional == null)
            return NotFound();

        Profissionais.Remove(profissional);
        return Ok();
    }*/
}
