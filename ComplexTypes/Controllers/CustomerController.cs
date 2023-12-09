using ComplexTypes.Migrations;
using Models = ComplexTypes.Models;
using Dto = ComplexTypes.Dto;
using Microsoft.AspNetCore.Mvc;
using ComplexTypes.Dto;

namespace ComplexTypes.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly Models.AppDbContext _dbContext;

    public CustomerController(Models.AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> SaveCustomer(Dto.Customer requestModel)
    {
        var customer = new Models.Customer
        {
            Name = requestModel.Name,
            Address = new() { Line1 = requestModel.AddressLine1, City = requestModel.City, Country = requestModel.Country, PostCode = requestModel.PostCode }
        };

        _dbContext.Add(customer);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }


}
