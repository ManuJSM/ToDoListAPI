
using API.Data;
using API.Dtos;
using API.Mappers;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly AppDbContext _context;
        public TodoListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TodoList> CreateAsync(TodoList todoListModel)
        {
            await _context.TodoLists.AddAsync(todoListModel);
            await _context.SaveChangesAsync();

            return todoListModel;
        }

        public async Task<TodoList?> DeleteAsync(int id)
        {
            var todoList = await _context.TodoLists
                .Include(t =>t.Items)
                .FirstOrDefaultAsync(x => x.Id == id);  

            if ( todoList != null){
                _context.TodoLists.Remove(todoList);
                await _context.SaveChangesAsync();
            }
                
            return todoList;
        }

        public async ValueTask<TodoList?> FindAsync(int id)
        {
            var todoList = await _context.TodoLists
                .Include(t =>t.Items)
                .FirstOrDefaultAsync(x => x.Id == id);              
            return todoList;

        }

        public async Task<List<TodoList>> GetAllListsAsync()
        {
            return await _context.TodoLists.ToListAsync();
        }

        public async Task<TodoList?> UpdateAsync(int id, TodoListPutDto todoListPutDto)
        {
            var todoList = await _context.TodoLists
                .Include(t =>t.Items)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(todoList != null){
                todoList.Title = todoListPutDto.Title;
                todoList.Items = todoListPutDto.Items.Select(s => s.ToTodoItemFromPutDto()).ToList();

                await _context.SaveChangesAsync();
            }

            return todoList;
        }
    }
}