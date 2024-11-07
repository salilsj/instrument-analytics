
using System.Net.Http.Json;
using System.Text.Json;
using InstrumentAnalyticsApi.Entities;

namespace InstrumentAnalyticsApi.Services.External;

public class MoodysRatingService : ServiceBase, IRatingService
{
    private const string MoodysRatingsRequestUri = "https://mocki.io/v1/11ab88f0-0a9a-44ad-ac40-334005fc5117";
    private readonly HttpClient _httpClient;

    public MoodysRatingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<RatingData>> GetAllAvailableRatingAsync()
    {
        try
        {
            // Send a GET request
            HttpResponseMessage response = await _httpClient.GetAsync(MoodysRatingsRequestUri);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Error getting data from external API. Please ensure the API at '" + MoodysRatingsRequestUri + "' is accessible.");
            }

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var serialised = JsonSerializer.Deserialize<RatingRoot>(responseBody, JsonSerializerOptionsDefault);
            return serialised?.values?.Select(r => new RatingData() { Isin = r.Isin, Rating = r.Rating, RatingType = RatingProviderType.Moodys }) ?? new List<RatingData>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

}
