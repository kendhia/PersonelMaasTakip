﻿using System;
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
        static IMongoCollection<Complaint> complaints = db.GetCollection<Complaint>("complaints");
        private bool v;
        private personels personels;
        private bool admin = true;

        public Form2(Boolean yonetici, String pId)
		{

          

            InitializeComponent();
            if (!yonetici)
            {
                admin = false;
                this.tabControl1.TabPages.Remove(tabPage1);
                dataGridView1.Visible = false;
                var resP = collection.Find(x => x.Id == new MongoDB.Bson.ObjectId(pId)).ToList();
                if (resP.Count > 0)
                {

                    nameTextBox.Text = resP[0].Name;
                    surnameTextBox.Text = resP[0].LastName;
                    salaryTextBox.Text = resP[0].Maas.ToString();
                    salaryTextBox.Enabled = false;
                    bonusTextBox.Text = resP[0].Prim.ToString();
                    bonusTextBox.Enabled = false;
                    ageComboBox.Text = resP[0].age.ToString();
                    sexComboBox.Text = resP[0].sex.ToString();
                    idTextBox.Text = resP[0].Id.ToString();
                    idTextBox.Enabled = false;
                    addNewButton.Visible = false;
                    dataGridView1.Visible = false;
                    complaintsDataGridView.Visible = false;
                }

            }
            else
            {
                List<personels> list = collection.AsQueryable().ToList<personels>();
                List<Complaint> listOfComplaints = complaints.AsQueryable().ToList<Complaint>();
                dataGridView2.DataSource = list;
                button6.Visible = false;
                textBox1.Visible = false;
                label1.Visible = false;
                complaintsDataGridView.DataSource = listOfComplaints;
            }

		}

    

        private void updateData()
        {
            if (admin)
            {
                collection = db.GetCollection<personels>("personeller");
                List<personels> list = collection.AsQueryable().ToList<personels>();
                dataGridView2.DataSource = list;
            }

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
            try
            {
                String name = nameTextBox.Text;
                String surName = surnameTextBox.Text;
                int salary = Convert.ToInt32(salaryTextBox.Text);
                int bonus = Convert.ToInt32(bonusTextBox.Text);
                String sex = sexComboBox.Text;
                int age = Convert.ToInt32(ageComboBox.Text);
                String lastLogin = dateTimePicker1.Value.ToUniversalTime().ToString();
                return new personels(name, surName, surName, "123456", salary, bonus, lastLogin, sex, age);
            } catch (Exception e)
            {
                MessageBox.Show("bir hata olmustur.");
            }

            return null;


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
            idTextBox.Text = "";
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
            personels myObject = GetPersonels();
            myObject.Id = new MongoDB.Bson.ObjectId(idTextBox.Text);
         
            var filter = Builders<personels>.Filter.Eq(s => s.Id, myObject.Id);

            var result =  collection.ReplaceOne(filter, myObject);
            updateData();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.Remove(tabPage1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            complaints.InsertOne(new Complaint(textBox1.Text, nameTextBox.Text));
            MessageBox.Show("Your message has been delivered.");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }
    }
}
