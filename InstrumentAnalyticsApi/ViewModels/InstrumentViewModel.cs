
namespace InstrumentAnalyticsApi.ViewModels;

public class InstrumentViewModel
{
    public string Isin { get; set; }
    public string Sedol { get; set; }
    public string Name { get; set; }
    public string InstrumentType { get; set; }
    public string BaseCurrency { get; set; }
    public string MoodysRating { get; set; }
    public string AnalystRating { get; set; }
}
