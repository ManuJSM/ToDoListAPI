

using API.Dtos;
using API.Models;

namespace API.Repositories.Interfaces
{
    public interface ITodoListRepository
    {
        Task<List<TodoList>> GetAllListsAsync();
        ValueTask<TodoList?> FindAsync(int id);
        Task<TodoList> CreateAsync(TodoList todoListModel);
        Task<TodoList?> DeleteAsync(int id);
        Task <TodoList?> UpdateAsync(int id, TodoListPutDto todoListPutDto);
    }
}