
using InstrumentAnalyticsApi.ControllerServices;
using InstrumentAnalyticsApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentAnalyticsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstrumentRatingsController : InstrumentAnalyticsBaseController
{
    private readonly IInstrumentRatingsControllerService _controllerService;

    public InstrumentRatingsController(IInstrumentRatingsControllerService controllerService)
    {
        _controllerService = controllerService;
    }

    [HttpGet]
    public async Task<IEnumerable<InstrumentViewModel>> GetInstrumentsWithRatings()
    {
        // we an apply filters in the params if we only need equities or bonds only data with some rating available 
        return await _controllerService.GetAllAvailableInstrumentRatingsAsync();
    }
}
