using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Classes;

[Route("api/[controller]")]
[ApiController]
public class ServicoController : ControllerBase
{
    private static List<Servico> Servicos = new List<Servico>();

    [HttpGet]
    public IActionResult GetServicos()
    {
        return Ok(Servicos);
    }

    [HttpPost]
    public IActionResult AdicionarServico([FromBody] Servico servico)
    {
        Servicos.Add(servico);
        return Ok(servico);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarServico(int id, [FromBody] Servico servico)
    {
        var servicoExistente = Servicos.FirstOrDefault(s => s.Id == id);
        if (servicoExistente == null)
            return NotFound();

        servicoExistente.Nome = servico.Nome;
        servicoExistente.Duracao = servico.Duracao;

        return Ok(servicoExistente);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarServico(int id)
    {
        var servico = Servicos.FirstOrDefault(s => s.Id == id);
        if (servico == null)
            return NotFound();

        Servicos.Remove(servico);
        return Ok();
    }
}
