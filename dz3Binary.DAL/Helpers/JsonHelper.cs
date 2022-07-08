using Newtonsoft.Json;

namespace dz3Binary.DAL.Helpers;

public static class JsonHelper
{
    private static readonly HttpClient _client = new();
    public static async Task<ICollection<T>> Get<T>(string routeName)
    {
        const string URL = "https://bsa-dotnet.azurewebsites.net/api/";
        var responseMessage = await _client.GetAsync(URL + routeName);
        var values = JsonConvert
            .DeserializeObject<LinkedList<T>>(await responseMessage.Content.ReadAsStringAsync());
        return values;
    }
}
