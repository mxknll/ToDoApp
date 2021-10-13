using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.DataAccess.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Status { get; set; } = "new";

        public enum StatusOptions
        {
            @new,
            active,
            done
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
