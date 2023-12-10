using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class TodoItemGetDto
    {
        public string Title { get; set; } = String.Empty;
        public bool IsCompleted { get; set; }   

    }
}