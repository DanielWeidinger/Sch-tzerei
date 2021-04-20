using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Schaetzerei.Core.Contracts;

namespace Schaetzerei.Core.Entities.Game
{
    public class Question : EntityObject
    {
        [Required]
        public string Heading { get; set; }

        [Required]
        public string Text { get; set; }

        public IAnswer Answer { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }

        public int GameId { get; set; }

    }
}
