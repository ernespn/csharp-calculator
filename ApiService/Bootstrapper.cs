using Nancy;
using Nancy.TinyIoc;
using Newtonsoft.Json;
using TodoService.Repositories;
using TodoService.Repositories.Mongo;

namespace ApiService
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<JsonSerializer, CustomJsonSerializer>();
            container.Register<ITodoRepository, TodoMongoRepository>();
        }
    }
}
