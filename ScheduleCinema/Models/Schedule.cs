namespace ScheduleCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Schedule")]
    public partial class Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schedule()
        {
            CinemaSessions = new HashSet<CinemaSession>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScheduleId { get; set; }

        public int CinemaId { get; set; }

        [Column(TypeName = "date")]
        public DateTime ScheduleDate { get; set; }

        [Required]
        [StringLength(500)]
        public string ScheduleDescription { get; set; }

        public virtual Cinema Cinema { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CinemaSession> CinemaSessions { get; set; }
    }
}
