using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class GameUser
    {
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int CorrectAnswers { get; set; }
        public int Rating { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
