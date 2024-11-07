using InstrumentAnalyticsApi.Entities;

namespace InstrumentAnalyticsApi.Services.External;

public interface IInstrumentService
{
    Task<IEnumerable<Instrument>> GetAllInstrumentsAsync();
}
