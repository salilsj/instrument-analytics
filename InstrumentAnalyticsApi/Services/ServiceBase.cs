using System.Text.Json;

namespace InstrumentAnalyticsApi.Services;

public abstract class ServiceBase
{
    protected JsonSerializerOptions JsonSerializerOptionsDefault
    {
        get
        {
            return new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
    }
}