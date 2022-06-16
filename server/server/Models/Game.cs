using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Game
    {
        public Game()
        {
            GameQuestions = new HashSet<GameQuestion>();
            GameUsers = new HashSet<GameUser>();
        }

        public int GameId { get; set; }
        public DateTime DateTime { get; set; }
        public int Manager { get; set; }
        public int CountQuestions { get; set; }

        public virtual User ManagerNavigation { get; set; }
        public virtual ICollection<GameQuestion> GameQuestions { get; set; }
        public virtual ICollection<GameUser> GameUsers { get; set; }
    }
}
