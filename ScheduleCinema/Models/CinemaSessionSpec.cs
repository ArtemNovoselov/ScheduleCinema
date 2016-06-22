namespace ScheduleCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CinemaSessionSpec")]
    public partial class CinemaSessionSpec
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CinemaSessionSpecId { get; set; }

        public TimeSpan CinemaSessionSpecTime { get; set; }

        [Column(TypeName = "money")]
        public decimal? CinemaSessionSpecPrice { get; set; }

        public int CinemaSessionId { get; set; }

        public virtual CinemaSession CinemaSession { get; set; }
    }
}
