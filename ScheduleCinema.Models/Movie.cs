using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleCinema.Models
{
    [Table("Movie")]
    public partial class Movie
    {
        public Movie()
        {
            CinemaSessions = new HashSet<CinemaSession>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }

        [Required]
        [StringLength(200)]
        public string MovieName { get; set; }

        [Required]
        [StringLength(100)]
        public string MovieDirector { get; set; }

        public TimeSpan MovieDuration { get; set; }
        
        public virtual ICollection<CinemaSession> CinemaSessions { get; set; }
    }
}
