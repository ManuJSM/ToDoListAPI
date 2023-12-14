

namespace API.Dtos
{
    public class TodoItemPutDto
    {
        public string Title { get; set; } = String.Empty;
        public bool IsCompleted { get; set; }
    }
}