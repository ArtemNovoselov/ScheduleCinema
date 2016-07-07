using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ScheduleCinema.Models.Interfaces;

namespace ScheduleCinema.Models.DBMS.SqlServerDB
{
    [Table("CinemaSession")]
    public partial class CinemaSession : ICinemaSession
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

        public virtual DBMS.MongoDB.Cinema Cinema { get; set; }
        
        [DisplayName("Время сеансов")]
        public virtual ICollection<CinemaSessionSpec> CinemaSessionSpecs { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
