using ProyectoApi.Models;

namespace ProyectoApi.Controllers
{
    public static class WeatherForecastController
    {
        public static void ConfiguracionRutas(WebApplication app)
        {
            var weatherForecast = new List<WeatherForecast>();

            app.MapGet("/weatherforecast/{index}", (int index) =>
            {
                if (index < 0 || index >= weatherForecast.Count)
                {
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
                    return Results.Ok(new { Message = $"El ID {index} fue eliminado exitosamente." });
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
        }
    }
}
