

using API.Models;

namespace API.Repositories
{
    public interface ITodoListRepository
    {
        Task<List<TodoList>> GetAllListsAsync();
        ValueTask<TodoList?> FindAsync(int id);
    }
}