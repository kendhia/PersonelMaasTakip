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
		public personels(string name, string lastName, string kullaniciAdi, string password, int maas, int prim)
		{
			Name = name;
			LastName = lastName;
			KullaniciAdi = kullaniciAdi;
			Password = password;
			Maas = maas;
			Prim = prim;
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
	}
}
