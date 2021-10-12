using System.ComponentModel.DataAnnotations;

namespace ToDoApp.BlazorServerUI.Models
{
    public class NewAssignmentModel
    {
        [Required]
        public string Caption { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
