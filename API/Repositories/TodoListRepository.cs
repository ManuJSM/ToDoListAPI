
using API.Data;
using API.Models;
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
    }
}