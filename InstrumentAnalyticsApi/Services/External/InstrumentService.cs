using System.Text.Json;
using InstrumentAnalyticsApi.Entities;

namespace InstrumentAnalyticsApi.Services.External;

public class InstrumentService : ServiceBase, IInstrumentService
{
    private const string InstrumentServiceRequestUri = "https://mocki.io/v1/5c913cd3-77b2-43b7-9c74-0982e6174298";

    private readonly HttpClient _httpClient;

    public InstrumentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Instrument>> GetAllInstrumentsAsync()
    {
        try
        {
            // Send a GET request
            HttpResponseMessage response = await _httpClient.GetAsync(InstrumentServiceRequestUri);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Error getting data from external API. Please ensure the API at '" + InstrumentServiceRequestUri + "' is accessible.");
            }

            response.EnsureSuccessStatusCode();

            // Deserialize JSON response to a List of Instruments
            var responseBody = await response.Content.ReadAsStringAsync();



            var serialised = JsonSerializer.Deserialize<InstrumentRoot>(responseBody, JsonSerializerOptionsDefault);
            return serialised?.values ?? new List<Instrument>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
}
