using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SoftTrack
{
    public partial class add_object : Form
    {
        public main_window parentForm;
        public string mainQuery = "";

        public add_object(main_window main)
        {
            InitializeComponent();
            parentForm = main;
        }

        public void add_object_Load(object sender, EventArgs e)
        {
            this.Text = "Создание записи для " + parentForm.targetTable;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            switch (parentForm.targetTable)
            {
                case "Clients":
                    groupBox1.Enabled = true;
                    List<string> Software = parentForm.dataBase.SearchSoftware();
                    comboBox2.Items.Clear();
                    foreach (var item in Software)
                    {
                        comboBox2.Items.Add(item);
                    }
                    break;

                case "Software":
                    groupBox2.Enabled = true;
                    List<string> SoftwareCreators = parentForm.dataBase.SearchSoftwareCreators();
                    comboBox1.Items.Clear();
                    foreach (var item in SoftwareCreators)
                    {
                        comboBox1.Items.Add(item);
                    }
                    break;

                case "Software_creators":
                    groupBox3.Enabled = true;
                    break;

                case "Support":
                    groupBox4.Enabled = true;
                    List<string> Clients = parentForm.dataBase.SearchClient();
                    List<string> Softwares = parentForm.dataBase.SearchSoftware();
                    comboBox3.Items.Clear();
                    comboBox4.Items.Clear();
                    foreach (var item in Clients)
                    {
                        comboBox3.Items.Add(item);
                    }
                    foreach (var item in Softwares)
                    {
                        comboBox4.Items.Add(item);
                    }
                    break;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ExtractId(string comboBoxValue)
            {
                return string.IsNullOrEmpty(comboBoxValue) ? "" : comboBoxValue.Split(':')[0].Trim();
            }

            if (groupBox1.Enabled)
            {
                mainQuery = $"INSERT INTO Clients (Name, [E-mail], Phone, software_id, sale_date, support_end) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{ExtractId(comboBox2.SelectedItem?.ToString())}', '{dateTimePicker1.Value}', '{dateTimePicker2.Value}')";
            }
            else if (groupBox2.Enabled)
            {
                mainQuery = $"INSERT INTO Software (Name, category, [license type], Price, creator_id) VALUES ('{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', '{textBox7.Text}', '{ExtractId(comboBox1.SelectedItem?.ToString())}')";
            }
            else if (groupBox3.Enabled)
            {
                mainQuery = $"INSERT INTO Software_creators (Name, [E-mail], Phone) VALUES ('{textBox8.Text}', '{textBox9.Text}', '{textBox10.Text}')";
            }
            else if (groupBox4.Enabled)
            {
                if(dateTimePicker4.Enabled == true)
                {
                    mainQuery = $"INSERT INTO Support (client_id, sofware_id, problem, Status, Request_date, Decision_date) VALUES ('{ExtractId(comboBox3.SelectedItem?.ToString())}', '{ExtractId(comboBox4.SelectedItem?.ToString())}', '{textBox11.Text}', '{textBox12.Text}', '{dateTimePicker3.Value}', '{dateTimePicker4.Value}')";
                }
                else
                {
                    mainQuery = $"INSERT INTO Support (client_id, sofware_id, problem, Status, Request_date, Decision_date) VALUES ('{ExtractId(comboBox3.SelectedItem?.ToString())}', '{ExtractId(comboBox4.SelectedItem?.ToString())}', '{textBox11.Text}', '{textBox12.Text}', '{dateTimePicker3.Value}', '{null}')";
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(dateTimePicker4.Enabled == true)
            {
                dateTimePicker4.Enabled = false;
            }
            else
            {
                dateTimePicker4.Enabled = true;
            }
        }
    }
}
