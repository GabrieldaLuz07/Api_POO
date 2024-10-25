using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Classes;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private static List<Cliente> Clientes = new List<Cliente>();

    [HttpGet]
    public IActionResult GetClientes()
    {
        return Ok(Clientes);
    }

    [HttpPost]
    public IActionResult AdicionarCliente([FromBody] Cliente cliente)
    {
        Clientes.Add(cliente);
        return Ok(cliente);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarCliente(int id, [FromBody] Cliente cliente)
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
    }
}
