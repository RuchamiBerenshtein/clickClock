using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class User
    {
        public User()
        {
            GameUsers = new HashSet<GameUser>();
            Games = new HashSet<Game>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public virtual ICollection<GameUser> GameUsers { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
