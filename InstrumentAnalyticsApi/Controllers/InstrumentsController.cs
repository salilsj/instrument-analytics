
using InstrumentAnalyticsApi.Services.External;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentAnalyticsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstrumentsController : InstrumentAnalyticsBaseController
{
    private readonly IInstrumentService _instrumentService;

    public InstrumentsController(IInstrumentService instrumentService)
    {
        _instrumentService = instrumentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInstruments()
    {
        var instruments = await _instrumentService.GetAllInstrumentsAsync();

        return Ok(instruments);
    }
}
