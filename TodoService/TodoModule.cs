using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using System.Linq;
using TodoService.Models;
using TodoService.Repositories;

namespace TodoService
{
    public class TodoModule: NancyModule
    {
        private readonly ITodoRepository _todoRepository;

        public TodoModule(ITodoRepository repository)
        {
            _todoRepository = repository;

            Get["/todo"] = _ =>
            {
                var todos = _todoRepository.GetAll();
                return Response.AsJson(todos.ToList().Take(10));
            };

            Post["/todo"] = _ =>
            {
                var x = this.Bind<Todo>();
                _todoRepository.AddOrUpdateTodo(x);
                var todos = _todoRepository.GetAll();
                return Response.AsJson(todos.ToList().Take(10));
            };
        }

    }
}