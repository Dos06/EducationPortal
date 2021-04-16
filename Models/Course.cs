using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should fill this field in!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should fill this field in!")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [Display(Name = "Category")]
        public virtual Category Category { get; set; }
        public CourseDetails CourseDetails { get; set; }

        public virtual ICollection<Material> Materials { get; set; }

        //public virtual ICollection<UserToCourse> UserToCourses { get; set; }
    }
}
