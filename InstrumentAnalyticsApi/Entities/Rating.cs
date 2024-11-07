namespace InstrumentAnalyticsApi.Entities;

public class RatingData
{
    public string Isin { get; set; }
    public string Rating { get; set; }

    public RatingProviderType RatingType { get; set; }
}

public class RatingRoot{
    public IEnumerable<RatingData> values{get; set;}
}
