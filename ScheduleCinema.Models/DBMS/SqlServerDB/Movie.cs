using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ScheduleCinema.Models.Interfaces;

namespace ScheduleCinema.Models.DBMS.SqlServerDB
{
    [Table("Movie")]
    public partial class Movie : IMovie
    {
        public Movie()
        {
            CinemaSessions = new HashSet<CinemaSession>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Фильм")]
        public string MovieName { get; set; }

        [Required]
        [StringLength(100)]
        public string MovieDirector { get; set; }

        public TimeSpan MovieDuration { get; set; }
        
        public virtual ICollection<CinemaSession> CinemaSessions { get; set; }
    }
}
