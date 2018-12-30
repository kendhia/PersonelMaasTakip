using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;
using MongoDB.Driver;

namespace deneme
{
	public partial class Form2 : Form
	{

		static MongoClient client = new MongoClient();
		static IMongoDatabase db = client.GetDatabase("personeltakip");
		static IMongoCollection<personels> collection = db.GetCollection<personels>("personeller");

		public Form2()
		{
			InitializeComponent();
			List<personels> list = collection.AsQueryable().ToList<personels>();
			dataGridView1.DataSource = list;
		}

		

		

		

		private void Form2_Load(object sender, EventArgs e)
		{
			
			
		}
	}
}
