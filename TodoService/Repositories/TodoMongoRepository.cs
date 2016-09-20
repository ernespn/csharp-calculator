using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoService.Models;

namespace TodoService.Repositories
{
    class TodoMongoRepository : ITodoRepository
    {
        public void AddOrUpdateTodo(Todo todo)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTodo(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Todo GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
