namespace ScheduleCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Movie")]
    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CinemaSession> CinemaSessions { get; set; }
    }
}
