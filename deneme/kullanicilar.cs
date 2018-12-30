using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
	class kullanicilar
	{
		public kullanicilar(string name, string lastName, string kullaniciAdi, string password)
		{
			Name = name;
			LastName = lastName;
			KullaniciAdi = kullaniciAdi;
			Password = password;
		}

		[BsonId]
		public ObjectId Id { get; set; }
		[BsonElement("Name")]
		public String Name { get; set; }
		[BsonElement("LastName")]
		public String LastName { get; set; }
		[BsonElement("kullaniciAdi")]
		public String KullaniciAdi { get; set; }

		[BsonElement("Password")]
		public String Password { get; set; }
	}
}

	

