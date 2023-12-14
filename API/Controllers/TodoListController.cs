
using API.Dtos;
using API.Mappers;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/TodoList")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListRepository _todoListRepo;
        public TodoListController(ITodoListRepository todoListRepository )
        {
            _todoListRepo = todoListRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(){

            var todoList = await _todoListRepo.GetAllListsAsync();
            var todoListDto = todoList.Select (s => s.ToTodoListGetDto());
            return Ok(todoListDto);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetListById([FromRoute] int id){

            var todoList = await _todoListRepo.FindAsync(id);

            if (todoList == null){

                return NotFound();
            }
            var todoListDto = todoList.ToTodoListFindDto();
           
            return Ok(todoListDto);
        }


        [HttpPost]
        public async Task<ActionResult> CreateTodoList([FromBody] TodoListPostDto todoListPostDto)
        {
            var todoListModel = todoListPostDto.ToTodoListFromPostDto();
            
            await _todoListRepo.CreateAsync(todoListModel);
            
            return CreatedAtAction(nameof(GetListById), new { id = todoListModel.Id }, todoListModel.ToTodoListFindDto());
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteList([FromRoute] int id){

            var todoList = await _todoListRepo.DeleteAsync(id);  
            
            if (todoList == null){

                return NotFound();
            }

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id , [FromBody] TodoListPutDto todoListPutDto){

            var TodoList = await _todoListRepo.UpdateAsync(id,todoListPutDto);

            if(TodoList == null)
                return NotFound();

            return Ok(TodoList.ToTodoListFindDto());
        }
    }
}