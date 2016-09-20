using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoService.Models;

namespace TodoService.Repositories.Mongo
{
    public class TodoMongoRepository : ITodoRepository
    {
        protected static string _collection = "todos";
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public TodoMongoRepository()
        {
            _client = new MongoClient("mongodb://192.168.99.100:27017");
            _database = _client.GetDatabase("services");
        }

        public void AddOrUpdateTodo(Todo todo)
        {
            InsertOneAsync(todo);
        }

        private async void InsertOneAsync(Todo todo)
        {
            var document = todo.ToBsonDocument();
            var collection = _database.GetCollection<BsonDocument>("todos");
            await collection.InsertOneAsync(document);
        }

        public bool DeleteTodo(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> GetAll()
        {
            var todos = GetTodos();
            return todos.Result;
        }

        private async Task<IEnumerable<Todo>> GetTodos()
        {
            var collection = _database.GetCollection<BsonDocument>(_collection);
            var filter = new BsonDocument();
            var todos = new List<Todo>();
            var count = 0;
            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        todos.Add(BsonSerializer.Deserialize<Todo>(document));
                    }
                }
            }

            return todos;
        }

        public Todo GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
