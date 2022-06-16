using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Answer
    {
        public Answer()
        {
            Questions = new HashSet<Question>();
        }

        public int AnsId { get; set; }
        public string AnsContent { get; set; }
        public int QuestId { get; set; }

        public virtual Question Quest { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
