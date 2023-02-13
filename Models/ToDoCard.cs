using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoCard
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Task Discription")]
        public string Discription { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}