using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ScheduleCinema.Models.Interfaces;

namespace ScheduleCinema.Models.DBMS.SqlServerDB
{
    [Table("Cinema")]
    public partial class Cinema : ICinema
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
        [DisplayName("Кинотеатр")]
        public string CinemaName { get; set; }
        
        public virtual ICollection<CinemaSession> CinemaSessions { get; set; }
    }
}
