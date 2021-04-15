﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace EduPortal.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should fill this field in!")]
        [Display(Name = "User")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [Display(Name = "User")]
        public virtual IdentityUser User { get; set; }

        [Required(ErrorMessage = "You should fill this field in!")]
        [StringLength(1000, ErrorMessage = "Content is too short!")]
        public string Title { get; set; }

        [Display(Name = "Picture URL")]
        [DataType(DataType.ImageUrl)]
        public string PictureUrl { get; set; }

        [Required(ErrorMessage = "You should fill this field in!")]
        public string Text { get; set; }


        [Required(ErrorMessage = "You should fill this field in!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
