using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace SikmyVrhApi.Controllers
{
    [ApiController]
    [Route("api/AngledThrow")]
    public class AngledThrowController : ControllerBase
    {
        [HttpGet]
        [Route("id")]
        public Coordinatas Hello()
        {
            var result = new Coordinatas(17.01, 26.02);
            return result;
        }

        [HttpGet]
        public CalculatedAngledThrow CalculateAngledThrow(double angle, double velocity)
        {
            var result = new CalculatedAngledThrow();

            double angleRad = (angle * Math.PI) / 180;
            double stepTime = 0.1;
            double g = 9.81;

            double finishTime = ((2 * velocity * Math.Sin(angleRad) / g));

            result.tds = Math.Round((2 * velocity * Math.Sin(angleRad)) / g,4);
            result.FinishTime = Math.Round(finishTime, 4);
            result.HighestPoint = Math.Round(((velocity * velocity) * Math.Sin(angleRad) * Math.Sin(angleRad)) / (2 * g),4);

            for (double i = 0; i <= finishTime; i += stepTime)
            {
                var step = i;
                double x = (velocity * step * Math.Cos(angleRad));
                double y = ((velocity * step * Math.Sin(angleRad))) - ((g * (step * step)) / 2);

                var coords = new Coordinatas(Math.Round(x,4), Math.Round(y, 4));
                result.StepCount++;
                result.Coords.Add(coords);
            }

            double distance = ((velocity * velocity) * Math.Sin(2 * angleRad)) / g;
            result.Coords.Add(new Coordinatas(Math.Round(distance, 4), 0.0));
            result.StepCount++;
            result.DistanceTraveled = Math.Round(distance,4);

            return result;
        }
    }
}
