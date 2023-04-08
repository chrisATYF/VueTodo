using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VueTodoBackEnd.Models
{
    public class TodoItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Note { get; set; }
        public bool IsComplete { get; set; }
    }
}
