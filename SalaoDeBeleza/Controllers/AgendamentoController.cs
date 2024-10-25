using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.DataBase;
using SalaoDeBeleza.Services;

[Route("api/[controller]")]
[ApiController]
public class AgendamentoController : ControllerBase
{
    private readonly AgendamentoComponent service;
    public AgendamentoController(AgendamentoComponent _service)
    {
        service = _service;
    }


    [HttpGet]
    public List<Agendamento> GetAgendamentos()
    {
       return new List<Agendamento>();
    }

    [HttpPost]
    public IActionResult AgendarServico([FromBody] Agendamento agendamentoVO)
    {
        // Antes de agendar o horário, verifica se o profissional está disponível
        Profissional profissional = agendamentoVO.Profissional;
        if (!profissional.Disponivel)
        {
            return BadRequest("O profissional não está disponível para esta data e horário.");
        }

        Agendamento agendamento = new Agendamento(agendamentoVO.Cliente, agendamentoVO.Servico, profissional, agendamentoVO.Horario);
        agendamento.Profissional.Disponivel = false;
        service.Insert(agendamento);
        return Ok(agendamento);
    }

    /*[HttpPut("{id}")]
    public IActionResult AtualizarAgendamento(int id, [FromBody] Agendamento agendamento)
    {
        var agendamentoExistente = Agendamentos.FirstOrDefault(a => a.Id == id);
        if (agendamentoExistente == null)
            return NotFound();

        agendamentoExistente.Cliente = agendamento.Cliente;
        agendamentoExistente.Servico = agendamento.Servico;
        agendamentoExistente.Profissional = agendamento.Profissional;
        agendamentoExistente.DataHora = agendamento.DataHora;

        return Ok(agendamentoExistente);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarAgendamento(int id)
    {
        var agendamento = Agendamentos.FirstOrDefault(a => a.Id == id);
        if (agendamento == null)
            return NotFound();

        agendamento.Profissional.Disponivel = true; // Libera o profissional
        Agendamentos.Remove(agendamento);
        return Ok();
    }*/
}
