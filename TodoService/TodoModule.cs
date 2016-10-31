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
                var response = Response.AsJson(_todoRepository.GetAll().ToList());
                return CrossOrigin(response);
            };

            Post["/todo"] = _ =>
            {
                var x = this.Bind<Todo>();
                _todoRepository.AddOrUpdateTodo(x);
                var response =  Response.AsJson(_todoRepository.GetAll().ToList().Take(10));
                return CrossOrigin(response);
            };

            Delete["/todo/{id}"] = parameters =>
            {
                _todoRepository.DeleteTodo(parameters.id);
                var response = Response.AsJson(_todoRepository.GetAll().ToList().Take(10));
                return CrossOrigin(response);
            };

            Get["/todo/{id}"] = parameters =>
            {
                Todo todo = _todoRepository.GetById(parameters.id);
                var response = Response.AsJson(todo);
                return CrossOrigin(response);
            };
        }

        private Response CrossOrigin(Response response) {
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, OPTIONS");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }
    }
}