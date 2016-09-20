using Nancy;
using Nancy.Testing;
using Xunit;

namespace ApiServiceTests
{
    public class ApiServiceTests
    {
        [Fact]
        public void Should_return_404_when_route_not_find()
        {
            // Given
            var browser = new Browser(new DefaultNancyBootstrapper());

            // When
            var result = browser.Get("/", with => {
                with.HttpRequest();
            });

            // Then
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
