
using API.Dtos;
using API.Models;

namespace API.Mappers
{
    public static class TodoListMappers
    {
        public static TodoListGetDto ToTodoListGetDto (this TodoList todoList){

            return new TodoListGetDto{
                     
                Title = todoList.Title,
                Id = todoList.Id
                
            };
        }

        public static TodoListFindDto ToTodoListFindDto(this TodoList todoList){
           
            return new TodoListFindDto{

                Id = todoList.Id,
                
                Title = todoList.Title,

                Items = todoList.Items.Select(s => s.ToTodoItemGetDto()).ToList()
            };
        }

        public static TodoList ToTodoListFromPostDto(this TodoListPostDto todoListPostDto){

            return new TodoList{
                Title = todoListPostDto.Title,
                Items = todoListPostDto.Items.Select(s => s.ToTodoItemFromPostDto()).ToList()
            
            };
        }

        
    }
}