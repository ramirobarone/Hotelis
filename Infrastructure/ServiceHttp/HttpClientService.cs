using System.Text;

namespace Infrastructure.ServiceHttp
{
    public class HttpClientService<Tin, TOut>(HttpClient httpClient) : IHttpClientService<Tin, TOut>
    {
        public async Task<TOut> Post(string url, Tin data)
        {
            TOut model = default;

            var conten = new StringContent(System.Text.Json.JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, conten);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                if (response.Content != null)
                    model = System.Text.Json.JsonSerializer.Deserialize<TOut>(await conten.ReadAsStringAsync());

                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new Exception("Problemas al realizar el pago.");

            return model;
        }
    }
}
