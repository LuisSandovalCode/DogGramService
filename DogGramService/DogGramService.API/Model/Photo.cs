using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGramService.API.Model
{
    public class Photo
    {
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; }
        public string URI { get; set; }
        public int Likes { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
