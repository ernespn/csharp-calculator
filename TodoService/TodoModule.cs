using Nancy;
using System.Linq;
using TodoService.Repositories;

namespace TodoService
{
    public class TodoModule: NancyModule
    {
        public TodoModule(ITodoRepository repository)
        {
            Get["/todo"] = _ =>
            {
                return repository.GetAll().ToList().Take(10);
            };
        }

    }
}