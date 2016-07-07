using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using ScheduleCinema.Models.Interfaces;

namespace ScheduleCinema.Models.DBMS.MongoDB
{
    [Table("Cinema")]
    public class Cinema : ICinema
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public int CinemaId { get; set; }
        
        public string CinemaAddress { get; set; }
        
        public string CinemaName { get; set; }
        
        public ICollection<MongoDBRef> CinemaSessions { get; set; }
    }
}
