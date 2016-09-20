using Nancy;
using Nancy.Testing;
using Xunit;
using TodoService;

namespace TodoServiceTests
{
    public class TodoServiceTests
    {
        [Fact]
        public void Should_return_status_ok_when_route_exist()
        {
            // Given
            var browser = new Browser(with => with.Module<TodoModule>());

            // When
            var result = browser.Get("/todo/", with => {
                with.HttpRequest();
            });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            
        }
    }
}
