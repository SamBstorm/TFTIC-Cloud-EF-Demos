using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01.Entities
{
    internal class ServerDetails
    {
        public int ServerDetailsId { get; set; }
        public string IpAddress { get; set; }
        //[ForeignKey(nameof(Software))]
        public int SoftwareId { get; set; }
        public Software Software { get; set; }
    }
}
