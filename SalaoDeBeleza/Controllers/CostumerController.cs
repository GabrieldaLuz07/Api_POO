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
    private ILogger<ServiceController> logger;
    public CostumerController(DBContextInMemory db, ILogger<ServiceController> iLogger)
    {
        customerComponent = new CustomerComponent(db);
        logger = iLogger;
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
        logger.LogInformation("Post Cliente");
        try
        {
            customerComponent.Insert(dto);

            logger.LogInformation("Cliente cadastrado com sucesso.");

            return Ok("Cliente cadastrado com sucesso!");
        } 
        catch (Exception ex)
        {
            logger.LogInformation("Cliente não cadastrado. Motivo: " + ex.Message);
            return BadRequest(ex.Message);
        }
    }

    // Atualizar um cliente existente
    [HttpPut("{id}")]
    public IActionResult UpdateCustomers(int id, [FromBody] CustomerDTO dto)
    {
        logger.LogInformation("Put Cliente");
        try
        {
            customerComponent.Update(id, dto);

            logger.LogInformation("Cliente atualizado com sucesso.");

            return Ok("Cliente atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            logger.LogInformation("Cliente não atualizado. Motivo: " + ex.Message);
            return BadRequest(ex.Message);
        }
    }

    // Excluir um cliente
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomers(int id)
    {
        logger.LogInformation("Delete Cliente");
        try
        {
            customerComponent.Delete(id);

            logger.LogInformation("Cliente excluído com sucesso.");

            return Ok("Cliente excluído com sucesso!");
        } 
        catch (Exception ex)
        {
            logger.LogInformation("Cliente não excluido. Motivo: " + ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
