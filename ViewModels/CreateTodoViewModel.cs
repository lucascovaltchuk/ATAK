using System.ComponentModel.DataAnnotations;

namespace MeuTodo.ViewModels
{
    public class CreateTodoViewModel
    {
        [Required]
        public string Desc { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Status { get; set; }
    }
}