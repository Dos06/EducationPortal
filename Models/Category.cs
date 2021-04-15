using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should fill this field in!")]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
