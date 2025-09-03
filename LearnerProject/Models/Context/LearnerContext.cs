using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Context
{
    public class LearnerContext : DbContext
    {
        // Bütün sınıflar için "DbSet" tanımlamaları burada yapılır.
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CourseRegister> CourseRegisters { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<CourseVideo> CourseVideos { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<About> Abouts { get; set; }




    }
}