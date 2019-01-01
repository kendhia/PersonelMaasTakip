using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
    class personels
    {
        public personels(string name, string lastName, string kullaniciAdi,
            string password, int maas, int prim, String lastLogin, String sex, int age)
        {
            this.Name = name;
            this.LastName = lastName;
            this.KullaniciAdi = kullaniciAdi;
            this.Password = password;
            this.Maas = maas;
            this.Prim = prim;
            this.age = age;
            this.sex = sex;
            this.lastlogin = lastlogin;
           
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]

        public String Name { get; set; }
        [BsonElement("LastName")]
        public String LastName { get; set; }
        [BsonElement("kullaniciAdi")]
        public String KullaniciAdi { get; set; }

        [BsonElement("Password")]
        public String Password { get; set; }
        [BsonElement("Maas")]
        public int Maas { get; set; }
        [BsonElement("Prim")]

        public int Prim { get; set; }

        [BsonElement("age")]
        public int age{get; set;}

        [BsonElement("sex")]
        public String sex { get; set; }

        [BsonElement("lastlogin")]
        public String lastlogin { get; set; }
	}
}
