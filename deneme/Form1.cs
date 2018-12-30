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
using MongoDB.Driver;

namespace deneme
{
	public partial class Form1 : Form
	{
		static MongoClient client = new MongoClient();
		static IMongoDatabase db = client.GetDatabase("personeltakip");
		static IMongoCollection<kullanicilar> collection = db.GetCollection<kullanicilar>("kullanicilar");
		static IMongoCollection<personels> collection1 = db.GetCollection<personels>("personeller");

		public void ControlUser()
		{
			List<kullanicilar> list = collection.AsQueryable().ToList<kullanicilar>();
			var sonuc = collection.Find(x => x.KullaniciAdi == textBox1.Text).ToList();
			var sonuc2 = collection.Find(x => x.Password == textBox2.Text).ToList();
			var sonuc3 = collection.Find(x => x.KullaniciAdi == textBox1.Text).ToList();
			var sonuc4 = collection.Find(x => x.Password == textBox2.Text).ToList();

			if (sonuc.Count > 0 && sonuc2.Count > 0 && radioButton1.Checked==true)
			{
				this.Hide();
				Form2 frm2 = new Form2();
				frm2.Show();

			}
			else if (sonuc.Count > 0 && sonuc2.Count > 0 && radioButton2.Checked == true)
			{
				this.Hide();
				Form3 frm3 = new Form3();
				frm3.Show();

			}
			else { MessageBox.Show("Yanlış kullanıcı adı veya parola"); }



		}

		public Form1()
		{
			InitializeComponent();

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			ControlUser();


		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
