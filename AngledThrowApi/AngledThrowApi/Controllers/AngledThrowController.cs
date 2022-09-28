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
        public List<string> Hello()
        {
            
            return new List<string> { "Hello vilag" };
        }

        [HttpGet]
        public CalculatedAngledThrow CalculateAngledThrow(double angle, double velocity)
        {
            var result = new CalculatedAngledThrow();

            double angleRad = (angle * Math.PI) / 180;
            double stepTime = 0.2;
            double g = 9.81;

            double finishTime = ((2 * velocity * Math.Sin(angleRad) / g)) / stepTime;

            result.tds = (2 * velocity * Math.Sin(angleRad)) / g;
            result.FinishTime = finishTime;
            result.HighestPoint = ((velocity * velocity) * Math.Sin(angleRad) * Math.Sin(angleRad)) / (2 * g);

            for (int i = 0; i <= Math.Round(finishTime); i++)
            {
                var step = stepTime * i;
                double x = (velocity * step * Math.Cos(angleRad));
                double y = ((velocity * step * Math.Sin(angleRad))) - ((g * step * step) / 2);
                var coords = new Coordinatas(x, y);
                result.StepCount++;
                result.Coords.Add(coords);
            }

            double distance = ((velocity * velocity) * Math.Sin(2 * angleRad)) / g;
            result.Coords.Add(new Coordinatas(distance, 0));
            result.DistanceTraveled = distance;

            return result;
        }
    }
}
