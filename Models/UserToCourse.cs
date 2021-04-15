using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EduPortal.Models
{
    public class UserToCourse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual Course Course { get; set; }
    }
}
