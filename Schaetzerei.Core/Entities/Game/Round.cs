using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Schaetzerei.Core.Entities.Game
{
    public class Round : EntityObject
    {
        public RoundType Type { get; set; }

        public ICollection<Question> Questions { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }

    public enum RoundType
    {
        Geography, Math
    }
}
