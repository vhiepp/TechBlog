using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechBlog.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }
        public User() {}
    }
}