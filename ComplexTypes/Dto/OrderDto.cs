namespace ComplexTypes.Dto;

public class OrderDto
{
    public int CustomerId { get; set; }
    public string Content { get; set; }

    public bool EqualityForBillingAddress { get; set; }

    public AddressDto ShippinAddress { get; set; }
}

public class AddressDto
{
    public required string Line1 { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public required string PostCode { get; set; }
}