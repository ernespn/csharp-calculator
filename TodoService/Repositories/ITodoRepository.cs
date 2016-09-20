using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoService.Models;

namespace TodoService.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(string id);
        void AddOrUpdateTodo(Todo todo);
        bool DeleteTodo(string id);
                
    }
}
