var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var weatherForecast = new List<WeatherForecast>();

app.MapGet("/weatherforecast/{index}", (int index) =>
{
    if(index < 0 || index >= weatherForecast.Count){
        return Results.NotFound(new { Message = $"El ID {index} está fuera del rango." });
    }
    return Results.Ok(weatherForecast[index]);
});

app.MapPost("/weatherforecast", (WeatherForecast weather) =>
{
    weatherForecast.Add(weather);
    return Results.Created($"/weatherforecast/{weatherForecast.Count - 1}", weather);
});

app.MapDelete("/weatherforecast/{index}", (int index) =>
{
    if (index >= 0 && index <= weatherForecast.Count)
    {
        weatherForecast.RemoveAt(index);
        return Results.Ok(new { Message = $"El ID {index} fue eliminado exitosamente."});
    }
    else
    {
        return Results.NotFound(new { Message = $"El ID {index} está fuera del rango." });
    }
});

app.MapPut("/weatherforecast/{index}", (int index, WeatherForecast updatedForecast) =>
{
    if (index < 0 || index >= weatherForecast.Count)
    {
        return Results.NotFound(new { Message = $"El ID {index} está fuera del rango." });
    }

    weatherForecast[index] = updatedForecast;

    return Results.Ok(new { Message = $"El ID {index} fue actualizado exitosamente.", Data = weatherForecast[index] });
});

app.MapGet("/weatherforecast", () => weatherForecast)
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
