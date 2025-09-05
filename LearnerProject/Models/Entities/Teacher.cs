using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Graduate { get; set; }
        public string Experience { get; set; }
        public string ExperienceYear { get; set; }
        public string Skill { get; set; }
        public string Certificate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public List<CourseVideo> CourseVideos { get; set; }
    }
}