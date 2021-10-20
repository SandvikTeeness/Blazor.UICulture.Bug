using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Blazor.UICulture.Bug.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

        private Timer eventTriggerTimer;
        public EventHandler TimerTickEvent;

        private void TimerEventCallback(object state)
        {
            TimerTickEvent?.Invoke(this, EventArgs.Empty);
        }

        public void StartTimer()
        {
            eventTriggerTimer = new Timer(TimerEventCallback, null, 2000, 2000);
        }

        public void StopTimer()
        {
            eventTriggerTimer?.Dispose();
            eventTriggerTimer = null;
        }



    }
}
