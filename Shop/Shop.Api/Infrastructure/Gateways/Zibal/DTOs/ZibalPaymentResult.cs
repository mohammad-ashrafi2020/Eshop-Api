namespace Shop.Api.Infrastructure.Gateways.Zibal.DTOs;

internal class ZibalPaymentResult
{
    public long TrackId { get; set; }
    public int Result { get; set; }
    public string Message { get; set; }
}