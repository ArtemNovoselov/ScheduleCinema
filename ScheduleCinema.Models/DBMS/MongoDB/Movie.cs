using System;
using System.Collections.Generic;
using MongoDB.Bson;
using ScheduleCinema.Models.Interfaces;

namespace ScheduleCinema.Models.DBMS.MongoDB
{
    public class Movie : IMovie
    {
        
        public int MovieId { get; set; }
        
        public string MovieName { get; set; }
        
        public string MovieDirector { get; set; }

        public TimeSpan MovieDuration { get; set; }
        
        public ICollection<ObjectId> CinemaSessions { get; set; }
    }
}
