using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SoftTrack
{
    public class DataBase
    {
        public string connectionString = "Data Source=HOME-PC;Initial Catalog=accounting_distributed_software;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=HOME-PC;Initial Catalog=accounting_distributed_software;Integrated Security=True;TrustServerCertificate=True");

        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }

        public void LoadData(string table, DataGridView grid)
        {
             try
             {
                sqlConnection.Open();
                string query = $"SELECT * FROM {table}";
                SqlDataAdapter adapter = new(query, sqlConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid.DataSource = dt;
                sqlConnection.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
             }
        }

        public void Search(string searchText, string table, DataGridView Grid)
        {
                try
                {
                    sqlConnection.Open();
                    string query = ""; // Запрос по умолчанию
                switch (table)
                {
                    case "Clients":
                         query = "SELECT * FROM Clients";
                        break;

                    case "Software":
                         query = "SELECT * FROM Software";
                        break;

                    case "Software_creators":
                         query = "SELECT * FROM Software_creators";
                        break;

                    case "Support":
                         query = "SELECT * FROM Support";
                        break;
                }

                if (!string.IsNullOrWhiteSpace(searchText))
                    {
                    switch(table)
                    {
                        case "Clients":
                            query = @"
                            SELECT * FROM Clients 
                            WHERE Name LIKE @search
                            OR [E-mail] LIKE @search
                            OR Phone LIKE @search
                            OR CAST(software_id AS NVARCHAR) LIKE @search
                            OR CAST(sale_date AS NVARCHAR) LIKE @search";
                            break;

                        case "Software":
                            query = @"
                            SELECT * FROM Software 
                            WHERE Name LIKE @search
                            OR [category] LIKE @search
                            OR [license type] LIKE @search
                            OR CAST(id AS NVARCHAR) LIKE @search
                            OR CAST(Price AS NVARCHAR) LIKE @search";
                            break;

                        case "Software_creators":
                            query = @"
                            SELECT * FROM Software_creators 
                            WHERE Name LIKE @search
                            OR [E-mail] LIKE @search
                            OR Phone LIKE @search";
                            break;

                        case "Support":
                            query = @"
                            SELECT * FROM Support 
                            WHERE Name LIKE @search
                            OR [E-mail] LIKE @search
                            OR Phone LIKE @search
                            OR CAST(software_id AS NVARCHAR) LIKE @search
                            OR CAST(sale_date AS NVARCHAR) LIKE @search";
                            break;
                    }

                }

                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        if (!string.IsNullOrWhiteSpace(searchText))
                        {
                            cmd.Parameters.AddWithValue("@search", $"%{searchText}%");
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Grid.DataSource = dt;
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                    sqlConnection.Close();   
                }
        }

        public void LoadRept(string query, DataGridView grid)
        {
            try
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new(query, sqlConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid.DataSource = dt;
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки отчета: " + ex.Message);
            }
        }

        public void Delete(int target_id, string targetTable, DataGridView grid)
        {
            string query = $"DELETE FROM {targetTable} WHERE id = @target";

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@target", target_id);
                    int rowsAffected = cmd.ExecuteNonQuery(); // Выполняем удаление

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запись успешно удалена!");
                        RefreshGrid(targetTable, grid); // Обновляем таблицу
                    }
                    else
                    {
                        MessageBox.Show("Запись не найдена!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        // Метод для обновления DataGridView после удаления
        private void RefreshGrid(string table, DataGridView grid)
        {
            string query = "SELECT * FROM " + table; // Заново загружаем данные
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid.DataSource = dt;
            }
        }

        public List<string> SearchClient()
        {
            List<string> results = new List<string>();
            string query1 = "SELECT id, Name FROM Clients";

            sqlConnection.Open();

            using (SqlCommand command = new SqlCommand(query1, sqlConnection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string id = reader["id"].ToString();
                    string name = reader["Name"].ToString();
                    results.Add(id + " : " + name);
                }
            }

            sqlConnection.Close();
            return results;
        }

        public List<string> SearchSoftware()
        {
            List<string> results = new List<string>();
            string query1 = "SELECT id, Name FROM Software";

            sqlConnection.Open();

            using (SqlCommand command = new SqlCommand(query1, sqlConnection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string id = reader["id"].ToString();
                    string name = reader["Name"].ToString();
                    results.Add(id + " : " + name);
                }
            }

            sqlConnection.Close();
            return results;
        }

        public List<string> SearchSoftwareCreators()
        {
            List<string> results = new List<string>();
            string query1 = "SELECT id, Name FROM Software_creators";

            sqlConnection.Open();

            using (SqlCommand command = new SqlCommand(query1, sqlConnection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string id = reader["id"].ToString();
                    string name = reader["Name"].ToString();
                    results.Add(id + " : " + name);
                }
            }

            sqlConnection.Close();
            return results;
        }

        public void ExecuteNonQuery(string query)
        {
            sqlConnection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка выполнения запроса: " + ex.Message);
                }
            sqlConnection.Close();
        }

        public int UpdateSoftwarePrice(int creatorId, decimal priceIncrement)
        {
            sqlConnection.Open();
            using (SqlCommand command = new SqlCommand("UpdateSoftwarePrice", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CreatorID", creatorId);
                command.Parameters.AddWithValue("@PriceIncrement", priceIncrement);

                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public int CountClientsForUpdate(int softwareId)
        {
            try
            {
                openConnection();
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.CountClientsForUpdate(@SoftwareID)", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@SoftwareID", softwareId);
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения количества клиентов: " + ex.Message);
                return -1;
            }
            finally
            {
                closeConnection();
            }
        }
    }
}
