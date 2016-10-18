using Nancy.Testing;
using Nancy;
using CalculatorServices;
using CalculatorServices.Models;

using NUnit.Framework;

namespace CalculatorServiceTests
{
    [TestFixture]
    public class CalculatorModuleTests
    {
        [Test]
        public void Should_return_status_ok_when_route_exist()
        {
            // Given
            var browser = new Browser(with => with.Module<CalculatorModule>());

            // When
            var result = browser.Get("/add/3/4", with => {
                with.HttpRequest();
            });


            // Then
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
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
            Assert.AreEqual(7, value.result);
        }

        [Test]
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
            Assert.AreEqual("C# services", value.from);
        }

        [Test]
        public void Should_return_404_when_parameters_wrong()
        {
            // Given
            var browser = new Browser(with => with.Module<CalculatorModule>());

            // When
            var result = browser.Get("/add/3/ass", with => {
                with.HttpRequest();
            });

            // Then
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
