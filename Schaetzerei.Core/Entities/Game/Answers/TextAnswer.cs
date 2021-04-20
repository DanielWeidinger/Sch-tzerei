using System;
using System.Collections.Generic;
using System.Text;
using Schaetzerei.Core.Contracts;

namespace Schaetzerei.Core.Entities.Game.Answers
{
    class TextAnswer : IAnswer
    {
        public string Text { get; set; }

        public string GetAnswer()
        {
            throw new NotImplementedException();
        }
    }
}
