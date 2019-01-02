using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace deneme
{
    class Complaint

    {
        public Complaint(String content, String name)
        {
            this.content = content;
            this.name = name;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("content")]

        public String content { get; set; }

        [BsonElement("name")]

        public String name { get; set; }
    }
}
