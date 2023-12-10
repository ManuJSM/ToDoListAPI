
namespace API.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";

        // Necesita ser virtual igual que la Navigation property para el Lazy loading(no lo voy a usar)
        public List<TodoItem> Items { get; set; } = [];
    }
}