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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CinemaSession> CinemaSessions { get; set; }
    }
}
