
using InstrumentAnalyticsApi.Entities;
using InstrumentAnalyticsApi.ViewModels;

namespace InstrumentAnalyticsApi.ControllerServices;

public class InstrumentViewModelMapper
{
     public static InstrumentViewModel Map(Instrument instrument, RatingData analystRating, RatingData moodysRating)
    {
        return new InstrumentViewModel
        {
            Isin = instrument?.identifiers?.isin ?? string.Empty,
            Sedol = instrument?.identifiers?.sedol ?? string.Empty,
            Name = instrument?.name ?? string.Empty,
            InstrumentType = instrument?.instrumentDefinition?.instrumentType ?? string.Empty,
            BaseCurrency = instrument?.domCcy ?? string.Empty,
            MoodysRating = moodysRating?.Rating ?? "Not Available",
            AnalystRating = analystRating?.Rating ?? "Not Available"
        };
    }


     public static InstrumentViewModel Map(Instrument instrument, IEnumerable<RatingData> ratings)
    {
        return new InstrumentViewModel
        {
            Isin = instrument?.identifiers?.isin ?? string.Empty,
            Sedol = instrument?.identifiers?.sedol ?? string.Empty,
            Name = instrument?.name ?? string.Empty,
            InstrumentType = instrument?.instrumentDefinition?.instrumentType ?? string.Empty,
            BaseCurrency = instrument?.domCcy ?? string.Empty,
            MoodysRating = ratings.FirstOrDefault(r => r.RatingType == RatingProviderType.Moodys && r.Isin == instrument?.identifiers?.isin)?.Rating ?? "Not Available",
            AnalystRating = ratings.FirstOrDefault(r => r.RatingType == RatingProviderType.Analyst && r.Isin == instrument?.identifiers?.isin)?.Rating ?? "Not Available",
        };
    }
}