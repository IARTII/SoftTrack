using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftTrack
{
    public partial class change_object : Form
    {
        public main_window parentForm;
        public string mainQuery = "";
        public int objectId; // ID изменяемого объекта

        public change_object(main_window main, int id)
        {
            InitializeComponent();
            parentForm = main;
            objectId = id;
        }

        public void change_object_Load(object sender, EventArgs e)
        {
            this.Text = "Изменение записи в " + parentForm.targetTable;
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
                    LoadClientData();
                    break;

                case "Software":
                    groupBox2.Enabled = true;
                    List<string> SoftwareCreators = parentForm.dataBase.SearchSoftwareCreators();
                    comboBox1.Items.Clear();
                    foreach (var item in SoftwareCreators)
                    {
                        comboBox1.Items.Add(item);
                    }
                    LoadSoftwareData();
                    break;

                case "Software_creators":
                    groupBox3.Enabled = true;
                    LoadSoftwareCreatorsData();
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
                    LoadSupportData();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ExtractId(string comboBoxValue)
            {
                return string.IsNullOrEmpty(comboBoxValue) ? "" : comboBoxValue.Split(':')[0].Trim();
            }

            // Функция для извлечения целого числа из строки с учетом запятой
            int ExtractInt(string value)
            {
                if (string.IsNullOrEmpty(value))
                    return 0;

                // Обрезаем строку до первой запятой и преобразуем в число
                string cleanedValue = value.Split(',')[0].Trim();
                return Convert.ToInt32(cleanedValue);
            }

            DateTime saleDate = dateTimePicker1.Value;
            DateTime supportEnd = dateTimePicker2.Value;
            DateTime requestDate = dateTimePicker3.Value;
            DateTime decisionDate = dateTimePicker4.Value;

            if (groupBox1.Enabled)
            {
                mainQuery = $"UPDATE Clients SET Name = '{textBox1.Text}', [E-mail] = '{textBox2.Text}', Phone = '{textBox3.Text}', software_id = '{ExtractId(comboBox2.SelectedItem?.ToString())}', sale_date = '{saleDate}', support_end = '{supportEnd}' WHERE id = {objectId}";
            }
            else if (groupBox2.Enabled)
            {
                mainQuery = $"UPDATE Software SET Name = '{textBox4.Text}', category = '{textBox5.Text}', [license type] = '{textBox6.Text}', Price = '{ExtractInt(textBox7.Text)}', creator_id = '{ExtractId(comboBox1.SelectedItem?.ToString())}' WHERE id = {objectId}";
            }
            else if (groupBox3.Enabled)
            {
                mainQuery = $"UPDATE Software_creators SET Name = '{textBox8.Text}', [E-mail] = '{textBox9.Text}', Phone = '{textBox10.Text}' WHERE id = {objectId}";
            }
            else if (groupBox4.Enabled)
            {
                mainQuery = $"UPDATE Support SET client_id = '{ExtractId(comboBox3.SelectedItem?.ToString())}', sofware_id = '{ExtractId(comboBox4.SelectedItem?.ToString())}', problem = '{textBox11.Text}', Status = '{textBox12.Text}', Request_date = '{requestDate}', Decision_date = '{decisionDate}' WHERE id = {objectId}";
            }

        }

        private void LoadClientData()
        {
            string query = $"SELECT Name, [E-mail], Phone, software_id, sale_date, support_end FROM Clients WHERE id = {objectId}";
            using (SqlConnection connection = new SqlConnection(parentForm.dataBase.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox1.Text = reader["Name"].ToString();
                        textBox2.Text = reader["E-mail"].ToString();
                        textBox3.Text = reader["Phone"].ToString();
                        comboBox2.SelectedItem = reader["software_id"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(reader["sale_date"]);
                        dateTimePicker2.Value = Convert.ToDateTime(reader["support_end"]);
                    }
                }
            }
        }

        private void LoadSoftwareData()
        {
            string query = $"SELECT Name, category, [license type], Price, creator_id FROM Software WHERE id = {objectId}";
            using (SqlConnection connection = new SqlConnection(parentForm.dataBase.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox4.Text = reader["Name"].ToString();
                        textBox5.Text = reader["category"].ToString();
                        textBox6.Text = reader["license type"].ToString();
                        textBox7.Text = reader["Price"].ToString();
                        comboBox1.SelectedItem = reader["creator_id"].ToString();
                    }
                }
            }
        }

        private void LoadSoftwareCreatorsData()
        {
            string query = $"SELECT Name, [E-mail], Phone FROM Software_creators WHERE id = {objectId}";
            using (SqlConnection connection = new SqlConnection(parentForm.dataBase.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox8.Text = reader["Name"].ToString();
                        textBox9.Text = reader["E-mail"].ToString();
                        textBox10.Text = reader["Phone"].ToString();
                    }
                }
            }
        }

        private void LoadSupportData()
        {
            string query = $"SELECT client_id, sofware_id, problem, Status, Request_date, Decision_date FROM Support WHERE id = {objectId}";
            using (SqlConnection connection = new SqlConnection(parentForm.dataBase.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        comboBox3.SelectedItem = reader["client_id"].ToString();
                        comboBox4.SelectedItem = reader["sofware_id"].ToString();
                        textBox11.Text = reader["problem"].ToString();
                        textBox12.Text = reader["Status"].ToString();
                        dateTimePicker3.Value = Convert.ToDateTime(reader["Request_date"]);
                        dateTimePicker4.Value = Convert.ToDateTime(reader["Decision_date"]);
                    }
                }
            }
        }
    }
}
