using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EduPortal.Models;

namespace EduPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EduPortal.Models.Category> Category { get; set; }
        public DbSet<EduPortal.Models.Course> Course { get; set; }
        public DbSet<EduPortal.Models.Material> Material { get; set; }
        public DbSet<EduPortal.Models.CourseDetails> CourseDetails { get; set; }
    }
}
