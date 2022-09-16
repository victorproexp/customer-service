using Microsoft.AspNetCore.Mvc;
using CustomerService;

namespace customerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private static List<Customer> _customers = new List<Customer>() {
        new Customer() {
            Id = 1,
            Name = "International Bicycles A/S",
            Address1 = "Nydamsvej 8",
            Address2 = null,
            PostalCode = 8362,
            City = "Hørning",
            TaxNumber = "DK-75627732"
        },
        new Customer() {
            Id = 2,
            Name = "Nice Bikes A/S",
            Address1 = "Krystalgade 8",
            Address2 = null,
            PostalCode = 8700,
            City = "Horsens",
            TaxNumber = "DK-75617732"
        }
    };

    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}")]
    public Customer GetCustomer(int id)
    {
        _logger.LogInformation("GetCustomer called at {DT}",
            DateTime.UtcNow.ToLongTimeString());

        return _customers.Where(c => c.Id == id).First();
    }

    [HttpGet()]
    public List<Customer> GetCustomers()
    {
        _logger.LogInformation("GetCustomers called at {DT}",
            DateTime.UtcNow.ToLongTimeString());

        return _customers;
    }

    [HttpPost()]
    public Customer PostCustomer(Customer customer)
    {
        _logger.LogInformation("PostCustomer called at {DT}",
            DateTime.UtcNow.ToLongTimeString());

        try
        {
            _customers.Add(customer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return customer;
    }
}
