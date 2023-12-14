
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public bool IsCompleted { get; set; }
        
        [ForeignKey("TodoList")]
        public int TodoListId { get; set; }

        //Propiedad para navegar con lazy loading 
        public TodoList? TodoList { get; set; }
    }
}