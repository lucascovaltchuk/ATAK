using System;

namespace MeuTodo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        
        public string Status { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}