using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components;
using SalaoDeBeleza.DataBase;
using SalaoDeBeleza.DTOs;

[Route("api/[controller]")]
[ApiController]
public class CostumerController : ControllerBase
{
    private CustomerComponent customerComponent;
    public CostumerController(DBContextInMemory db)
    {
        customerComponent = new CustomerComponent(db);
    }

    // Buscar todos os clientes
    [HttpGet]
    public List<Customer> getCustomers()
    {
        return customerComponent.GetAll();
    }

    // Buscar um cliente específico pelo id
    [HttpGet("{id}")]
    public IActionResult getCustomerById(int id)
    {
        try
        {
            return Ok(customerComponent.GetById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Cadastrar um cliente
    [HttpPost]
    public IActionResult InsertCustomers([FromBody] CustomerDTO dto)
    {
        try
        {
            customerComponent.Insert(dto);
            return Ok("Cliente cadastrado com sucesso!");
        } 
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Atualizar um cliente existente
    [HttpPut("{id}")]
    public IActionResult UpdateCustomers(int id, [FromBody] CustomerDTO dto)
    {
        try
        {
            customerComponent.Update(id, dto);
            return Ok("Cliente atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Excluir um clientes
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomers(int id)
    {
        try
        {
            customerComponent.Delete(id);
            return Ok("Cliente excluído com sucesso!");
        } 
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
