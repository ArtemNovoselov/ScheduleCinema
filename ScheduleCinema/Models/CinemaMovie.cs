namespace ScheduleCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CinemaMovie")]
    public partial class CinemaMovie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CinemaMovieBindingId { get; set; }

        public int CinemaId { get; set; }

        public int MovieId { get; set; }

        [Column(TypeName = "date")]
        public DateTime CinemaMovieDate { get; set; }

        public TimeSpan CinemaMovieTime { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
