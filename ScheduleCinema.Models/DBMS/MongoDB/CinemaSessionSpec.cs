using System;
using System.ComponentModel.DataAnnotations.Schema;
using ScheduleCinema.Models.Interfaces;

namespace ScheduleCinema.Models.DBMS.MongoDB
{
    [Table("CinemaSessionSpec")]
    public partial class CinemaSessionSpec : ICinemaSessionSpec
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CinemaSessionSpecId { get; set; }

        public TimeSpan CinemaSessionSpecTime { get; set; }

        [Column(TypeName = "money")]
        public decimal? CinemaSessionSpecPrice { get; set; }

        public int CinemaSessionId { get; set; }

        public virtual Interfaces.CinemaSession CinemaSession { get; set; }
    }
}
