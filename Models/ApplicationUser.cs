using Microsoft.AspNetCore.Identity;
using System;

namespace UserManagementApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime RegistrationTime { get; set; } = DateTime.Now;
        public DateTime? LastLoginTime { get; set; }
        public bool IsBlocked { get; set; } = false;
    }
}
