using Nancy.Testing;
using Xunit;
using Nancy;
using CalculatorServices;
using CalculatorServices.Models;

namespace CalculatorServiceTests
{
    public class CalculatorModuleTest
    {
        [Fact]
        public void Should_return_status_ok_when_route_exist()
        {
            // Given
            var browser = new Browser(with => with.Module<CalculatorModule>());

            // When
            var result = browser.Get("/add/3/4", with => {
                with.HttpRequest();
            });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void Should_return_7_when_parameter_3_and_4_are_passed()
        {
            // Given
            var browser = new Browser(with => with.Module<CalculatorModule>());

            // When
            var result = browser.Get("/add/3/4", with => {
                with.HttpRequest();
            });

            // Then
            Calculation value = result.Body.DeserializeJson<Calculation>();
            Assert.Equal(7, value.result);
        }

        [Fact]
        public void Should_return_csharp_in_the_from_section()
        {
            // Given
            var browser = new Browser(with => with.Module<CalculatorModule>());

            // When
            var result = browser.Get("/add/3/4", with => {
                with.HttpRequest();
            });

            // Then
            Calculation value = result.Body.DeserializeJson<Calculation>();
            Assert.Equal("C# services", value.from);
        }
    }
}
