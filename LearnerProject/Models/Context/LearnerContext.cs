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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Course - Teacher (bire çok, cascade açık kalabilir)
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId)
                .WillCascadeOnDelete(true);

            // CourseVideo - Course (bire çok, cascade açık kalabilir)
            modelBuilder.Entity<CourseVideo>()
                .HasRequired(cv => cv.Course)
                .WithMany()
                .HasForeignKey(cv => cv.CourseId)
                .WillCascadeOnDelete(true);

            // CourseVideo - Teacher (bire çok ama cascade KAPALI olmalı!)
            modelBuilder.Entity<CourseVideo>()
                .HasRequired(cv => cv.Teacher)
                .WithMany(t => t.CourseVideos)
                .HasForeignKey(cv => cv.TeacherId)
                .WillCascadeOnDelete(false);
        }

    }
}