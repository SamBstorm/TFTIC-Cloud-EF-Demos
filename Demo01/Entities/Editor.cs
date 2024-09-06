using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01.Entities
{
    internal class Editor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Software> Softwares { get; set; }
    }
}
