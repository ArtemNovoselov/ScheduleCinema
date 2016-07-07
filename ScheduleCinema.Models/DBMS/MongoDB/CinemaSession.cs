using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using ScheduleCinema.Models.Interfaces;

namespace ScheduleCinema.Models.DBMS.MongoDB
{
    public class CinemaSession : ICinemaSession
    {
        
        public int CinemaSessionId { get; set; }

        public int CinemaId { get; set; }

        public int MovieId { get; set; }
        
        public DateTime CinemaSessionDate { get; set; }

        public Cinema Cinema { get; set; }
        
        [DisplayName("Время сеансов")]
        public ICollection<ObjectId> CinemaSessionSpecs { get; set; }

        public Movie Movie { get; set; }
    }
}
