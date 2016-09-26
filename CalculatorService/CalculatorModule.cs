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

                var response = Response.AsJson(new Calculation { result = x + y, from = "C# services" });
                response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
                response.Headers.Add("Access-Control-Allow-Methods", "GET, OPTIONS");
                response.Headers.Add("Access-Control-Allow-Origin", "*");
                return response;
            };
        }
    }
}
