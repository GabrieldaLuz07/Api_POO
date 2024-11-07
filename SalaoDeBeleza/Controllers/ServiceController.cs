using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components.DTOs;
using SalaoDeBeleza.Components;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private ServiceComponent serviceComponent;
    public ServiceController(ServiceComponent component)
    {
        serviceComponent = component;
    }


    [HttpGet]
    public List<Service> getServices()
    {
        return serviceComponent.getServices();
    }

    [HttpPost]
    public void InsertServices([FromBody] ServiceDTO dto)
    {
        serviceComponent.Insert(dto);
    }

    /*[HttpPut("{id}")]
    public IActionResult AtualizarServico(int id, [FromBody] Service servico)
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
    }*/
}
