
namespace API.Dtos
{
    public class TodoListPutDto
    {

        public string Title { get; set; } = "";
        public List<TodoItemPutDto> Items { get; set; } = [];
        
    }
}