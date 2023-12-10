
using API.Dtos;
using API.Models;

namespace API.Mappers
{
    public static class TodoItemMappers
    {

        public static TodoItemGetDto ToTodoItemGetDto(this TodoItem todoItem){

            return new TodoItemGetDto{

                Title = todoItem.Title,
                IsCompleted = todoItem.IsCompleted

            };

        }
        
    }
}