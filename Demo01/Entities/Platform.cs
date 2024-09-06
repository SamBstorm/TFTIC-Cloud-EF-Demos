using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01.Entities
{
    internal class Platform
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //public List<Game> Games { get; set; }
        public List<PlatformGame> PlatformGames { get; set; }
    }
}
