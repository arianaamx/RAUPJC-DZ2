using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface ITodoRepository
    {
        TodoItem Get(Guid todoId);
        //Gets TodoItem for a given id, returns : TodoItem if found, null otherwise

        void Add(TodoItem todoItem);
        //Adds new TodoItem object in database. If object with the same if already exists,
        //method should throw DuplicateTodoItemException with the messade "duplicate id : {id}"

        bool Remove(Guid todoId);
        //Tries to removve a TodoItem with given id from the database, returns : True if success,
        //false otherwise

        void Update(TodoItem todoItem);
        //Updates given TodoItem in database. If TodoItem does not exist, method will add one.

        bool MarkAsCompleted(Guid todoId);
        //Tries to mark a TodoItem as completed in database, returns : true if success, false otherwise

        List<TodoItem> GetAll();
        //Gets all TodoItem object in database, sorted by date created (descending)

        List<TodoItem> GetActive();
        //Gets all incomplete TodoItem objects in database

        List<TodoItem> GetCompleted();
        //Gets all completed TodoItem objects in database

        List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction);
        //Gets all TodoItem objects in database that apply to the filter
    }
}
