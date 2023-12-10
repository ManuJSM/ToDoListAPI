
namespace API.Dtos
{
    public class TodoListFindDto
    {
         public string Title { get; set; } = "";

         public List<TodoItemGetDto> Items { get; set; } = [];
    }

   
}