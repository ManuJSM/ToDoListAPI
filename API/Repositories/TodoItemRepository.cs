
using API.Data;
using API.Dtos;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class TodoItemRepository: ITodoItemRepository
    {
        private readonly AppDbContext _context;

        public TodoItemRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<TodoList?> AddToTodoListAsync(int id, TodoItem todoItemModel)
        {
            var todoList = await _context.TodoLists
                .Include(t =>t.Items)
                .FirstOrDefaultAsync(x => x.Id == id);
                
            if(todoList != null){

                todoList.Items.Add(todoItemModel);
                await _context.SaveChangesAsync();

            }
            return todoList;
        }

        public async Task<TodoItem?> DeleteAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if( todoItem != null){

                _context.Remove(todoItem);
                await _context.SaveChangesAsync();
            }

            return todoItem;
        }

        public async Task<TodoItem?> UpdateAsync(int id, TodoItemPutDto todoItemPutDto)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if(todoItem != null){

                todoItem.Title = todoItemPutDto.Title;
                todoItem.IsCompleted = todoItemPutDto.IsCompleted;
                await _context.SaveChangesAsync();
            }

            return todoItem;
        }
    }
}