using System.Net.Mime;
using System.Text;
using Common.Application.Validation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shop.Api.Infrastructure.Gateways.Zibal.DTOs;

namespace Shop.Api.Infrastructure.Gateways.Zibal;

internal class ZibalService : IZibalService
{
    private readonly HttpClient _httpClient;
    private static JsonSerializerSettings DefaultSerializerSettings => new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };
    public ZibalService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> StartPay(ZibalPaymentRequest request)
    {
        var body = JsonConvert.SerializeObject(request, DefaultSerializerSettings);
        var content = new StringContent(body, Encoding.UTF8, MediaTypeNames.Application.Json);
        var result = await _httpClient.PostAsync(ZibalOptions.RequestUrl, content);
        if (result.IsSuccessStatusCode)
        {
            var response = await result.Content.ReadFromJsonAsync<ZibalPaymentResult>();
            if (response!.Result == 100)
                return $"{ZibalOptions.PaymentUrl}{response.TrackId}";

            throw new InvalidCommandException(ZibalTranslator.TranslateResult(response!.Result));
        }
        throw new InvalidCommandException(result.StatusCode.ToString());
    }

    public async Task<ZibalVeriyfyResponse> Verify(ZibalVeriyfyRequest request)
    {
        var body = JsonConvert.SerializeObject(request, DefaultSerializerSettings);
        var content = new StringContent(body, Encoding.UTF8, MediaTypeNames.Application.Json);
        var result = await _httpClient.PostAsync(ZibalOptions.VerifyUrl, content);
        if (result.IsSuccessStatusCode)
        {
            return await result.Content.ReadFromJsonAsync<ZibalVeriyfyResponse>();
        }
        throw new InvalidCommandException(result.StatusCode.ToString());
    }
}