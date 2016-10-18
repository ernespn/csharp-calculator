using Nancy;
using Nancy.Testing;

using NUnit.Framework;

namespace ApiServiceTests
{
    [TestFixture]
    public class ApiServiceTests
    {
        [Test]
        public void Should_return_404_when_route_not_find()
        {
            // Given
            var browser = new Browser(new DefaultNancyBootstrapper());

            // When
            var result = browser.Get("/", with => {
                with.HttpRequest();
            });

            // Then
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
