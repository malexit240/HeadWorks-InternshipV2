using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace HWInternshipProject.Models
{
    public class User
    {
        private static Guid _currentUserId = Guid.Empty;

        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string HashPassword { get; set; }
        public List<Profile> Profiles { get; set; } = new List<Profile>();
        public static User Current
        {
            get
            {
                using (var context = new Context())
                {
                    return _currentUserId == Guid.Empty ? null : (from user in context.users.Include(u => u.Profiles) where user.UserId == _currentUserId select user).First();
                }
            }
            set => _currentUserId = value?.UserId ?? Guid.Empty;
        }
    }
}
