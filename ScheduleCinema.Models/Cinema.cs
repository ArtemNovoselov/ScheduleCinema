using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleCinema.Models
{
    [Table("Cinema")]
    public partial class Cinema
    {
        public Cinema()
        {
            CinemaSessions = new HashSet<CinemaSession>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CinemaId { get; set; }

        [Required]
        [StringLength(200)]
        public string CinemaAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string CinemaName { get; set; }
        
        public virtual ICollection<CinemaSession> CinemaSessions { get; set; }
    }
}
