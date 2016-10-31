using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    // Implementirati ovo sučelje na način da baza podataka bude in-memory lokacija (IGenericList).
    //Ta lista implementira IEnumerable sučelje!

    public class TodoRepository : ITodoRepository
    //Class that encapsulates all the logic for accessing TodoItems
    //Repository does not fetch todoItems from the actual database, it uses in memory storage
    //for this excersize
        {
        private readonly List<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(List<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;        
            }
            else
            {
                _inMemoryTodoDatabase = new List<TodoItem>();
            }
            //kraće : _inMemoryTodoDatabase = initialDbState ?? new List<TodoItems>();
            // x?? y ---> if x is not null, expression returns x, else y.
        }

        //implement ITodoRepository
        public void Add(TodoItem todoItem)
        {
            if (todoItem == null)
                throw new ArgumentException($"Null object");

            if (_inMemoryTodoDatabase.Any(T => T.Id == todoItem.Id))
                 throw new DuplicateTodoItemException($"Duplicate : {todoItem.Id}");
            
            _inMemoryTodoDatabase.Add(todoItem);
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(T => T.Id == todoId);
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(T => T.IsCompleted==false).ToList();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(T => T.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(T => T.IsCompleted==true).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {

            return _inMemoryTodoDatabase.Where(T=> filterFunction(T)==true).ToList();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            var item = _inMemoryTodoDatabase.FirstOrDefault(T => T.Id == todoId);

            if (item == null)
                return false;

            item.MarkAsCompleted();
            return true;
        }

        public bool Remove(Guid todoId)
        {
            return _inMemoryTodoDatabase.Remove(_inMemoryTodoDatabase.FirstOrDefault(T => T.Id == todoId));
        }

        public void Update(TodoItem todoItem)
        {
            if (todoItem == null)
                throw new ArgumentException(); 

            var item = _inMemoryTodoDatabase.FirstOrDefault(T => T.Id == todoItem.Id);

            if (item != null)
            {
                item.Text = todoItem.Text;
                item.DateCreated = todoItem.DateCreated;
                item.DateCompleted = todoItem.DateCompleted;
                item.IsCompleted = todoItem.IsCompleted;
            }

            else
            {
                _inMemoryTodoDatabase.Add(todoItem);
            }
        }
    }
  
}
