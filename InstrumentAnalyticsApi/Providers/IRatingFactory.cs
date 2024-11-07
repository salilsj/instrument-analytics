using InstrumentAnalyticsApi.Services.External;

namespace InstrumentAnalyticsApi.Providers;

public interface IRatingFactory
{
    IRatingService CreateRatingService(RatingProviderType ratingProvider);
}
