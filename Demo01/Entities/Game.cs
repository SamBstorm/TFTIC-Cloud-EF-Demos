using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01.Entities
{
    /* Configuration par Data-Annotations
    internal class Game
    {
        [Key]   //Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   //Identity
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Column(nameof(PegiClassification),TypeName ="CHAR(3)")]
        public string PegiClassification { get; set; }
        [Required]
        public bool IsOnline { get; set; }
        public bool IsSplitScreen { get; set; }
    }*/

    internal class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PegiClassification { get; set; }
        public bool IsOnline { get; set; }
        public bool IsSplitScreen { get; set; }
    }
}
