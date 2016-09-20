using Nancy;
using CalculatorServices.Models;

namespace CalculatorServices
{
    public class CalculatorModule : NancyModule
    {
        public CalculatorModule()
        {
            Get["/add/{x:int}/{y:int}"] = parameters =>
            {
                int x = parameters.x;
                int y = parameters.y;

                return Response.AsJson(new Calculation { result = x + y, from = "C# services" });
            };
        }
    }
}
