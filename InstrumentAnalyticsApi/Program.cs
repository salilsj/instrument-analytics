using InstrumentAnalyticsApi.ControllerServices;
using InstrumentAnalyticsApi.Providers;
using InstrumentAnalyticsApi.Services.External;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<InstrumentService>();
builder.Services.AddHttpClient<MoodysRatingService>();
builder.Services.AddHttpClient<AnalystRatingService>();

builder.Services.AddScoped<IInstrumentService, InstrumentService>();
builder.Services.AddScoped<IRatingFactory, RatingFactory>();
builder.Services.AddScoped<IInstrumentRatingsControllerService, InstrumentRatingsControllerService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var corsPolicyWebClient = "analyticsWebClientOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyWebClient,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")       // This is usually fed from env configs so that only the correct origin is allowed 
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

var app = builder.Build();

app.UseCors(corsPolicyWebClient);

// Control if Swagger is required only for dev or all envs.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Instrument Analytics API");
            });;
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
