using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.DataBase;
using SalaoDeBeleza.Components;
using SalaoDeBeleza.Components.DTOs;

[Route("api/[controller]")]
[ApiController]
public class SchedulingController : ControllerBase
{
    private SchedulingComponent schedulingComponent;
    public SchedulingController(SchedulingComponent component)
    {
        schedulingComponent = component;
    }


    [HttpGet]
    public List<Scheduling> getAgendamentos()
    {
       return schedulingComponent.getAgendamentos();
    }

    [HttpPost]
    public void AgendarServico([FromBody] SchedulingDTO dto)
    {
        // Antes de agendar o horário, verifica se o profissional está disponível
        //Professional profissional = dto.Professional;
        /*if (!profissional.Disponivel)
        {
            return BadRequest("O profissional não está disponível para esta data e horário.");
        }*/

        schedulingComponent.Insert(dto);
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
