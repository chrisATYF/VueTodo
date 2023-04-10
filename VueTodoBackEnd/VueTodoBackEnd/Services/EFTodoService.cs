using Microsoft.EntityFrameworkCore;
using VueTodoBackEnd.Models;
using VueTodoBackEnd.Services.Interfaces;

namespace VueTodoBackEnd.Services
{
    public class EFTodoService : ITodo
    {
        protected readonly TodoDbContext _context;
        public EFTodoService(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetItem(int id)
        {
            return await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<TodoItem> AddItem(TodoItem model)
        {
            await _context.TodoItems.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }
        public async Task<TodoItem> UpdateItem(int id, TodoItem model)
        {
            var modelToUpdate = await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == model.Id);
            
            modelToUpdate.Id = model.Id;
            modelToUpdate.Title = model.Title;
            modelToUpdate.Note = model.Note;
            modelToUpdate.TodoDate = model.TodoDate;
            modelToUpdate.IsComplete = model.IsComplete;

            await _context.SaveChangesAsync();

            return modelToUpdate;
        }
        public void DeleteItem(int id)
        {
            var model = _context.TodoItems.FirstOrDefault(t => t.Id == id);

            if (model != null)
            _context.TodoItems.Remove(model);
            _context.SaveChanges();
        }
    }
}
