using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class GameQuestion
    {
        public int GameId { get; set; }
        public int QuestId { get; set; }
        public int Index { get; set; }

        public virtual Game Game { get; set; }
        public virtual Question Quest { get; set; }
    }
}
