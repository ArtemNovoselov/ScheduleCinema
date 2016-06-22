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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CinemaSession()
        {
            CinemaSessionSpecs = new HashSet<CinemaSessionSpec>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CinemaSessionId { get; set; }

        public int CinemaId { get; set; }

        public int MovieId { get; set; }

        [Column(TypeName = "date")]
        public DateTime CinemaSessionDate { get; set; }

        public virtual Cinema Cinema { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CinemaSessionSpec> CinemaSessionSpecs { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
