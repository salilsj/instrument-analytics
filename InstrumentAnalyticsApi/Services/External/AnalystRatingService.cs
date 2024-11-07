
using System.Net.Http.Json;
using System.Text.Json;
using InstrumentAnalyticsApi.Entities;
using Microsoft.AspNetCore.SignalR;

namespace InstrumentAnalyticsApi.Services.External;

public class AnalystRatingService : ServiceBase, IRatingService
{
    // Adding this as a constant as this is a specific URL. But this can be injected from constructor or can vbe read from a config with a config service injected from the constructor.
    private const string ExternalAnalystRatingsRequestUri = "https://mocki.io/v1/1cf057a5-e4c7-4cd3-9701-fbf29d379a39";
    private readonly HttpClient _httpClient;

    public AnalystRatingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<RatingData>> GetAllAvailableRatingAsync()
    {
        try
        {
            // Send a GET request
            HttpResponseMessage response = await _httpClient.GetAsync(ExternalAnalystRatingsRequestUri);
            
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Error getting data from external API. Please ensure the API at '" + ExternalAnalystRatingsRequestUri + "' is accessible.");
            }

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var serialised = JsonSerializer.Deserialize<RatingRoot>(responseBody, JsonSerializerOptionsDefault);
            return serialised?.values?.Select(r => new RatingData() { Isin = r.Isin, Rating = r.Rating, RatingType = RatingProviderType.Analyst }) ?? new List<RatingData>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

}
