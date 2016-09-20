using Nancy;
using System.Linq;
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
        }

    }
}