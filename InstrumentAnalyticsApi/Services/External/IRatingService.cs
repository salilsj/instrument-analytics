
using InstrumentAnalyticsApi.Entities;

namespace InstrumentAnalyticsApi.Services.External;

public interface IRatingService
{
    Task<IEnumerable<RatingData>> GetAllAvailableRatingAsync();
}
