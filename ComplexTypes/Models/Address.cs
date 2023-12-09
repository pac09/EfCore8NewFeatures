using System.ComponentModel.DataAnnotations.Schema;

namespace ComplexTypes.Models;

[ComplexType]
public class Address
{
    public required string Line1 { get; set; }
    public string? Line2 { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public required string PostCode { get; set; }
}
