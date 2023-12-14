
using API.Dtos;
using API.Models;

namespace API.Mappers
{
    public static class TodoItemMappers
    {

        public static TodoItemGetDto ToTodoItemGetDto(this TodoItem todoItem){

            return new TodoItemGetDto{

                Id = todoItem.Id,
                Title = todoItem.Title,
                IsCompleted = todoItem.IsCompleted

            };

        }

        public static TodoItem ToTodoItemFromPostDto (this TodoItemPostDto todoItemPostDto){

            return new TodoItem{
                Title = todoItemPostDto.Title,
                IsCompleted = false
            };
        }

        public static TodoItem ToTodoItemFromPutDto (this TodoItemPutDto todoItemPutDto){

            return new TodoItem{
                Title = todoItemPutDto.Title,
                IsCompleted = todoItemPutDto.IsCompleted
            };
        }
        
    }
}