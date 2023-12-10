
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
                
                Title = todoList.Title,

                Items = todoList.Items.Select(s => s.ToTodoItemGetDto()).ToList()
            };
        }

        
    }
}