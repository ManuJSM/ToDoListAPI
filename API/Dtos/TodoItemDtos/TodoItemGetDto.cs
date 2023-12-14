
namespace API.Dtos
{
    public class TodoItemGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public bool IsCompleted { get; set; }   

    }
}