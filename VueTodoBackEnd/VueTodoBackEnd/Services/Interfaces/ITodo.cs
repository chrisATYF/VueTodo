using VueTodoBackEnd.Models;

namespace VueTodoBackEnd.Services.Interfaces
{
    public interface ITodo
    {
        Task<List<TodoItem>> GetTodoItems();
        Task<TodoItem> GetItem(int id);
        Task<TodoItem> AddItem(TodoItem model);
        Task<TodoItem> UpdateItem(int id, TodoItem model);
        void DeleteItem(int id);
    }
}
