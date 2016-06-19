namespace ScheduleCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CinemaSession")]
    public partial class CinemaSession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CinemaSessionId { get; set; }

        public int CinemaId { get; set; }

        public int MovieId { get; set; }

        public TimeSpan CinemaSessionTime { get; set; }

        public int ScheduleId { get; set; }

        [Column(TypeName = "money")]
        public decimal CinemaSessionPrice { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Schedule Schedule { get; set; }
    }
}
