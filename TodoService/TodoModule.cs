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
                return Response.AsJson(_todoRepository.GetAll().ToList().Take(10));
            };
        }

    }
}