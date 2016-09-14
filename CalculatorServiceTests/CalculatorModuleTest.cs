using Nancy.Testing;
using Xunit;
using Nancy;

namespace CalculatorServiceTests
{
    public class CalculatorModuleTest
    {
        [Fact]
        public void Should_return_status_ok_when_route_exist()
        {
            // Given
            var browser = new Browser(with => with.Module<SimpleModule>());

            // When
            var result = browser.Get("/", with => {
                with.HttpRequest();
            });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
