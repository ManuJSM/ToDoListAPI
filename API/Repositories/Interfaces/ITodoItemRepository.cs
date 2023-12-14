
using API.Dtos;
using API.Models;

namespace API.Repositories.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<TodoList?> AddToTodoListAsync(int id, TodoItem todoItemModel);
        Task<TodoItem?> DeleteAsync(int id);
        Task<TodoItem?> UpdateAsync(int id, TodoItemPutDto todoItemPutDto);
    }
}