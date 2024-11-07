
using InstrumentAnalyticsApi.Entities;
using InstrumentAnalyticsApi.Services.External;
using InstrumentAnalyticsApi.Providers;
using InstrumentAnalyticsApi.ViewModels;
using InstrumentAnalyticsApi.Services;
using System.Security.Policy;

namespace InstrumentAnalyticsApi.ControllerServices;

public interface IInstrumentRatingsControllerService
{
    Task<IEnumerable<InstrumentViewModel>> GetAllAvailableInstrumentRatingsAsync();
}

public class InstrumentRatingsControllerService : IInstrumentRatingsControllerService
{
    private readonly IInstrumentService _instrumentService;
    private readonly IRatingFactory _ratingFactory;

    public InstrumentRatingsControllerService(IInstrumentService instrumentService, IRatingFactory ratingFactory)
    {
        _instrumentService = instrumentService;
        _ratingFactory = ratingFactory;
    }

    public async Task<IEnumerable<InstrumentViewModel>> GetAllAvailableInstrumentRatingsAsync()
    {
        var instruments = await _instrumentService.GetAllInstrumentsAsync();

        var moodysRatingService = _ratingFactory.CreateRatingService(RatingProviderType.Moodys);
        var moodysRatings = await moodysRatingService.GetAllAvailableRatingAsync();


        var analystRatingService = _ratingFactory.CreateRatingService(RatingProviderType.Analyst);
        var analystRatings = await analystRatingService.GetAllAvailableRatingAsync();

        // Option 1 - send all ratings options to the mapper as there is a posibility that for certain securities, we will have both ratings. 
        // var result = instruments.Select((i) => InstrumentViewModelMapper.Map(i, analystRatings.FirstOrDefault(r => r.Isin == i.identifiers.isin), moodysRatings.FirstOrDefault(r => r.Isin == i.identifiers.isin)));


        // option 2 - get all ratings together and based on the logic send all in an ienumerable
        var allRatings = moodysRatings.Concat(analystRatings);
        var result = instruments.Select((i) => InstrumentViewModelMapper.Map(i, allRatings.Where(r => r.Isin == i.identifiers.isin)));

        return result;
    }
}
