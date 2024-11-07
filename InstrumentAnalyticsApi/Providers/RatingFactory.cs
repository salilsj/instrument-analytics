
using System.ComponentModel;
using InstrumentAnalyticsApi.Services.External;

namespace InstrumentAnalyticsApi.Providers;

public class RatingFactory : IRatingFactory
{
    // Further abstraction is possible by using Abstract Factory
    private readonly IServiceProvider _serviceProvider;

    public RatingFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IRatingService CreateRatingService(RatingProviderType ratingProvider)
    {
        return ratingProvider switch
        {
            RatingProviderType.Moodys => _serviceProvider.GetRequiredService<MoodysRatingService>(),
            RatingProviderType.Analyst => _serviceProvider.GetRequiredService<AnalystRatingService>(),
            _ => throw new InvalidEnumArgumentException("Err Code 100 - RatingProviderType does not match"), // A seperate factory to generate unique error codes for each exception handled by the API can be implemented here. 
        };
    }
}
