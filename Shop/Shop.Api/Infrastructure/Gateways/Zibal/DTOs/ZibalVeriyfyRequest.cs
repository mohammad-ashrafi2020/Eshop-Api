namespace Shop.Api.Infrastructure.Gateways.Zibal.DTOs;

public class ZibalVeriyfyRequest
{
    public ZibalVeriyfyRequest(long trackId, string merchant)
    {
        TrackId = trackId;
        Merchant = merchant;
    }

    public string Merchant { get; private set; }
    public long TrackId { get; private set; }
}