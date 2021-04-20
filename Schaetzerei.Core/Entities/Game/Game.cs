using System;
using System.Collections.Generic;
using System.Text;
using Schaetzerei.Core.Entities.UserManagment;

namespace Schaetzerei.Core.Entities.Game
{
    public class Game : EntityObject
    {
        public ICollection<User> Player { get; set; }
        public ICollection<Round> Rounds { get; set; }
    }
}
