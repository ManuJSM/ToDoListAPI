
using API.Mappers;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/TodoList")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListRepository _todoListRepository;
        public TodoListController(ITodoListRepository todoListRepository )
        {
            _todoListRepository = todoListRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(){

            var todoList = await _todoListRepository.GetAllListsAsync();
            var todoListDto = todoList.Select (s => s.ToTodoListGetDto());
            return Ok(todoListDto);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetListById([FromRoute] int id){

            var todoList = await _todoListRepository.FindAsync(id);

            if (todoList == null){

                return NotFound();
            }
            var todoListDto = todoList.ToTodoListFindDto();
           
            return Ok(todoListDto);
        }
    }
}