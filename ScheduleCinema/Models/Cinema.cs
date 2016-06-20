namespace ScheduleCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cinema")]
    public partial class Cinema
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cinema()
        {
            CinemaMovies = new HashSet<CinemaMovie>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CinemaId { get; set; }

        [Required]
        [StringLength(200)]
        public string CinemaAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string CinemaName { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CinemaMovie> CinemaMovies { get; set; }
    }
}
