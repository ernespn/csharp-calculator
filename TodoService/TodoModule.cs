using Nancy;
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
                return Response.AsJson(_todoRepository.GetAll().ToList());
            };

            Post["/todo"] = _ =>
            {
                var x = this.Bind<Todo>();
                _todoRepository.AddOrUpdateTodo(x);
                return Response.AsJson(_todoRepository.GetAll().ToList().Take(10));
            };

            Delete["/todo/{id}"] = parameters =>
            {
                _todoRepository.DeleteTodo(parameters.id);
                return Response.AsJson(_todoRepository.GetAll().ToList().Take(10));
            };

            Get["/todo/{id}"] = parameters =>
            {
                Todo todo = _todoRepository.GetById(parameters.id);
                return Response.AsJson(todo);
            };
        }

    }
}