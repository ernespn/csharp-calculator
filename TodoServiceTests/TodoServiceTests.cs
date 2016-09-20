using Nancy;
using Nancy.Testing;
using Xunit;
using TodoService;
using Moq;
using TodoService.Repositories;
using System.Collections.Generic;
using TodoService.Models;

namespace TodoServiceTests
{
    public class TodoServiceTests
    {
        [Fact]
        public void Should_return_status_ok_when_route_exist()
        {
            // Given
            var mockTodoRepository = new Mock<ITodoRepository>();

            mockTodoRepository.Setup(x => x.GetAll()).Returns(new List<Todo>());
            var browser = new Browser(with =>
                                        {
                                            with.Module<TodoModule>();
                                            with.Dependency<ITodoRepository>(mockTodoRepository.Object);
                                        }
                                
                                );

            // When
            var result = browser.Get("/todo/", with => {
                with.HttpRequest();
            });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            
        }
    }
}
