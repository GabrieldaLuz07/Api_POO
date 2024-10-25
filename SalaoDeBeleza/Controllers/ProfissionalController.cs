using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Classes;

[Route("api/[controller]")]
[ApiController]
public class ProfissionalController : ControllerBase
{
    /*private static List<Profissional> Profissionais = new List<Profissional>();

    [HttpGet]
    public IActionResult GetProfissionais()
    {
        return Ok(Profissionais);
    }

    [HttpPost]
    public IActionResult AdicionarProfissional([FromBody] Profissional profissional)
    {
        Profissionais.Add(profissional);
        return Ok(profissional);
    }

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
