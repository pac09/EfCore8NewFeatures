using ComplexTypes.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ComplexTypes.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly Models.AppDbContext _dbContext;

    public OrdersController(Models.AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpPost]
    public async Task<IActionResult> CreateOrder(Dto.OrderDto requestModel)
    {
        var customer = _dbContext.Customers.Find(requestModel.CustomerId);

        _dbContext.Orders.Add(
            new Order
            {
                Contents = requestModel.Content,
                Customer = customer,
                BillingAddress = requestModel.EqualityForBillingAddress ? customer.Address : null, 
                ShippingAddress = new Address()
                {
                    Line1 = requestModel.ShippinAddress.Line1,
                    City = requestModel.ShippinAddress.City,
                    Country = requestModel.ShippinAddress.Country,
                    PostCode = requestModel.ShippinAddress.PostCode
                },
            });

        await _dbContext.SaveChangesAsync();

        return Ok();
    }

}
