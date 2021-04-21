using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schaetzerei.Core.Entities.Game
{
    public class Answer : EntityObject
    {
        [Required]
        public AnswerType Type { get; set; }

        [Required]
        public string Content { get; set; }
    }

    public enum AnswerType
    {
        Text, YesNo, Binary
    }
}
