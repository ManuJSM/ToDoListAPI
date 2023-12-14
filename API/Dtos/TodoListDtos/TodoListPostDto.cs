

namespace API.Dtos
{
    public class TodoListPostDto
    {
        public string Title { get; set; } = "";

        public List<TodoItemPostDto> Items { get; set; } = [];
    }
}