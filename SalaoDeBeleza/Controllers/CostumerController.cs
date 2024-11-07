using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components;
using SalaoDeBeleza.Components.DTOs;

[Route("api/[controller]")]
[ApiController]
public class CostumerController : ControllerBase
{
    private CustomerComponent customerComponent;
    public CostumerController(CustomerComponent component)
    {
        customerComponent = component;
    }

    [HttpGet]
    public List<Customer> getCustomers()
    {
        return customerComponent.getCustomers();
    }

    [HttpPost]
    public void InsertCustomers([FromBody] CustomerDTO dto)
    {
        customerComponent.Insert(dto);
    }

    /*
    [HttpPut("{id}")]
    public IActionResult AtualizarCliente(int id, [FromBody] Customer cliente)
    {
        var clienteExistente = Clientes.FirstOrDefault(c => c.Id == id);
        if (clienteExistente == null)
            return NotFound();

        clienteExistente.Nome = cliente.Nome;
        clienteExistente.Telefone = cliente.Telefone;
        clienteExistente.Email = cliente.Email;

        return Ok(clienteExistente);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarCliente(int id)
    {
        var cliente = Clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null)
            return NotFound();

        Clientes.Remove(cliente);
        return Ok();
    }*/
}
