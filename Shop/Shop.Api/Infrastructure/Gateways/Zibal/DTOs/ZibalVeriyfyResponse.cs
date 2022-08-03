namespace Shop.Api.Infrastructure.Gateways.Zibal.DTOs;

public class ZibalVeriyfyResponse
{
    public DateTime PaidAt { get; set; }
    public int Amount { get; set; }
    public int Result { get; set; }
    public int Status { get; set; }
    public int? RefNumber { get; set; }
    public string Description { get; set; }
    public string CardNumber { get; set; }
    public string OrderId { get; set; }
    public string Message { get; set; }
}