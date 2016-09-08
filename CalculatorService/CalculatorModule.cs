using Nancy;

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

                return Response.AsJson(new { result = x + y, from = "C# services" });
            };
        }
    }
}
