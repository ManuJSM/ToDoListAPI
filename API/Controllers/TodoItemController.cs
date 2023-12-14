
using API.Dtos;
using API.Mappers;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/TodoItem")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemRepository _todoItemRepo;
        public TodoItemController(ITodoItemRepository todoItemRepository )
        {
            _todoItemRepo = todoItemRepository;
        }

        [HttpPost("{id}")]

        public async Task<IActionResult> AddToTodoList([FromRoute] int id, [FromBody] TodoItemPostDto todoItemPostDto){

            var todoItemModel = todoItemPostDto.ToTodoItemFromPostDto();    
            var todoList = await _todoItemRepo.AddToTodoListAsync(id,todoItemModel);

            if (todoList == null){

                return NotFound();
            }
            // Para poder invocar a un metodo de otro controlador hay que añadir la ruta en el segundo parametro de la respuesta CreatedAtAction
            return CreatedAtAction(nameof(TodoListController.GetListById),"TodoList", new { id = todoList.Id } , todoList.ToTodoListFindDto());
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteTodoItem([FromRoute] int id){

            var todoItem = await _todoItemRepo.DeleteAsync(id);

            if (todoItem == null)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateTodoItem([FromRoute] int id , [FromBody] TodoItemPutDto todoItemPutDto){

            var todoItem = await _todoItemRepo.UpdateAsync(id,todoItemPutDto);

            if( todoItem == null)
                return NotFound();
            
            return Ok(todoItem.ToTodoItemGetDto());
        }

        
    }
}