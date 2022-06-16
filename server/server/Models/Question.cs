using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            GameQuestions = new HashSet<GameQuestion>();
        }

        public int QuestId { get; set; }
        public string Content { get; set; }
        public int Correctanswer { get; set; }
        public int Timer { get; set; }

        public virtual Answer CorrectanswerNavigation { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<GameQuestion> GameQuestions { get; set; }
    }
}
