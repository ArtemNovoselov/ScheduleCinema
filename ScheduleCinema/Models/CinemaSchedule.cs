namespace ScheduleCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CinemaSchedule")]
    public partial class CinemaSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CinemaSchedule()
        {
            CinemaSessions = new HashSet<CinemaSession>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CinemaScheduleId { get; set; }

        public int CinemaId { get; set; }

        [Column(TypeName = "date")]
        public DateTime ScheduleDate { get; set; }
        
        [StringLength(500)]
        public string ScheduleDescription { get; set; }

        public virtual Cinema Cinema { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CinemaSession> CinemaSessions { get; set; }
    }
}
