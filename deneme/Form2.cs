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
        private String id;

        public Form2()
		{
			InitializeComponent();
			List<personels> list = collection.AsQueryable().ToList<personels>();
			dataGridView2.DataSource = list;
		}

        private void updateData()
        {
           collection = db.GetCollection<personels>("personeller");
            List<personels> list = collection.AsQueryable().ToList<personels>();
            dataGridView2.DataSource = list;

        }
		

		

		

		private void Form2_Load(object sender, EventArgs e)
		{
			
			
		}

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox6_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

     

        private async void button6_Click(object sender, EventArgs e)
        {
            await collection.InsertOneAsync(GetPersonels());
            updateData();
        }

        private personels GetPersonels()
        {
            String name = nameTextBox.Text;
            String surName = surnameTextBox.Text;
            int salary = Convert.ToInt32(salaryTextBox.Text);
            int bonus = Convert.ToInt32(bonusTextBox.Text);
            String sex = sexComboBox.Text;
            int age = Convert.ToInt32(ageComboBox.Text);
            String lastLogin = dateTimePicker1.Value.ToUniversalTime().ToString();
            return new personels(name, surName, surName, "123456", salary, bonus, lastLogin, sex, age);


        }

 

 


      

        private void cancelButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
            salaryTextBox.Text = "";
            bonusTextBox.Text = "";
            ageComboBox.Text = "";
            sexComboBox.Text = "";
            dateTimePicker1.Text = "";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

                nameTextBox.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                surnameTextBox.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                salaryTextBox.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                bonusTextBox.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                ageComboBox.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                sexComboBox.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                idTextBox.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
      

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            personels myObject = GetPersonels(); // passed in 
            myObject.Id = new MongoDB.Bson.ObjectId(idTextBox.Text);
         
            var filter = Builders<personels>.Filter.Eq(s => s.Id, myObject.Id);

            var result =  collection.ReplaceOne(filter, myObject);
            updateData();

        }
    }
}
