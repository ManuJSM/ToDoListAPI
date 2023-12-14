
namespace API.Dtos
{
    public class TodoListFindDto
    {

        public int Id {get;set;}
         public string Title { get; set; } = "";

         public List<TodoItemGetDto> Items { get; set; } = [];
    }

   
}