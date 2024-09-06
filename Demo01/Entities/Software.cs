using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01.Entities
{
    internal abstract class Software
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsOnline { get; set; }
        public ServerDetails? ServerDetails { get; set; }
    }
}
