using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGramService.API.Model
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
