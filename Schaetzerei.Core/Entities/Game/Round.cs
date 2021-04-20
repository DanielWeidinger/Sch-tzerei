using System;
using System.Collections.Generic;
using System.Text;

namespace Schaetzerei.Core.Entities.Game
{
    public class Round : EntityObject
    {
        public RoundType Type { get; set; }

        public ICollection<Question> Questions { get; set; }

        []
        public Game Game { get; set; }
    }

    public enum RoundType
    {
        Geography, Math
    }
}
