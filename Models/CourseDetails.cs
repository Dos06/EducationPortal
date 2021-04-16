using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Models
{
    public class CourseDetails
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should fill this field in!")]
        public int Price { get; set; }

        [Required(ErrorMessage = "You should fill this field in!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You should fill this field in!")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        [Display(Name = "Course")]
        public virtual Course Course{ get; set; }
    }
}
