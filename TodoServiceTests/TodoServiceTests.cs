using Nancy;
using Nancy.Testing;

using NUnit.Framework;

using TodoService;
using Moq;
using TodoService.Repositories;
using System.Collections.Generic;
using TodoService.Models;
using System.Linq;

namespace TodoServiceTests
{
    [TestFixture]
    public class TodoServiceTests
    {
        [Test]
        public void Should_return_status_ok_when_route_exist()
        {
            // Given
            var mockTodoRepository = new Mock<ITodoRepository>();

            mockTodoRepository.Setup(x => x.GetAll()).Returns(new List<Todo>());
            var browser = new Browser(with => { with.Module<TodoModule>();
                                                with.Dependency<ITodoRepository>(mockTodoRepository.Object);
                                              });

            // When
            var result = browser.Get("/todo/", with => { with.HttpRequest(); });

            // Then
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            
        }

        [Test]
        public void Should_return_list_todos()
        {
            // Given
            var mockTodoRepository = new Mock<ITodoRepository>();
            var expectedList = new List<Todo> { new Todo() };

            mockTodoRepository.Setup(x => x.GetAll()).Returns(expectedList);
            var browser = new Browser(with =>
                                        {
                                            with.Module<TodoModule>();
                                            with.Dependency<ITodoRepository>(mockTodoRepository.Object);
                                        });

            // When
            var result = browser.Get("/todo/", with => { with.HttpRequest(); });
            IEnumerable<Todo> list = result.Body.DeserializeJson<IEnumerable<Todo>>();

            // Then
            Assert.AreEqual(expectedList.Count, list.ToList().Count);
            mockTodoRepository.Verify(x => x.GetAll(), Times.Once);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

        }

        [Test]
        public void Should_Save_Todos()
        {
            // Given
            var mockTodoRepository = new Mock<ITodoRepository>();
            var expectedList = new List<Todo> { new Todo() };

            mockTodoRepository.Setup(x => x.GetAll()).Returns(expectedList);
            var browser = new Browser(with =>
            {
                with.Module<TodoModule>();
                with.Dependency<ITodoRepository>(mockTodoRepository.Object);
            });

            // When
            var result = browser.Post("/todo/", with => { with.HttpRequest(); });
            IEnumerable<Todo> list = result.Body.DeserializeJson<IEnumerable<Todo>>();

            // Then
            Assert.AreEqual(expectedList.Count, list.ToList().Count);
            mockTodoRepository.Verify(x => x.GetAll(), Times.Once);
            mockTodoRepository.Verify(x => x.AddOrUpdateTodo(It.IsAny<Todo>()), Times.Once);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

        }

        [Test]
        public void Should_Delete_Todo()
        {
            // Given
            var mockTodoRepository = new Mock<ITodoRepository>();
            var expectedList = new List<Todo> { };

            mockTodoRepository.Setup(x => x.GetAll()).Returns(expectedList);
            var browser = new Browser(with =>
            {
                with.Module<TodoModule>();
                with.Dependency<ITodoRepository>(mockTodoRepository.Object);
            });

            // When
            var result = browser.Delete("/todo/33", with => { with.HttpRequest(); });
            IEnumerable<Todo> list = result.Body.DeserializeJson<IEnumerable<Todo>>();

            // Then
            mockTodoRepository.Verify(x => x.GetAll(), Times.Once);
            mockTodoRepository.Verify(x => x.DeleteTodo("33"), Times.Once);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

        }

        [Test]
        public void Should_Return_Todo_By_Id()
        {
            // Given
            var mockTodoRepository = new Mock<ITodoRepository>();
            var expectedTodo = new Todo { id = "12", what = "what" };

            mockTodoRepository.Setup(x => x.GetById(expectedTodo.id)).Returns(expectedTodo);
            var browser = new Browser(with =>
            {
                with.Module<TodoModule>();
                with.Dependency<ITodoRepository>(mockTodoRepository.Object);
            });

            // When
            var result = browser.Get(string.Format("/todo/{0}", expectedTodo.id), with => { with.HttpRequest(); });
            Todo todo = result.Body.DeserializeJson<Todo>();

            // Then
            mockTodoRepository.Verify(x => x.GetById(todo.id), Times.Once);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

        }
    }
}
