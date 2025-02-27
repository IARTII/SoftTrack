using System.Diagnostics.Tracing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SoftTrack
{
    public partial class main_window : Form
    {

        public DataBase dataBase = new DataBase();
        public string targetTable = "";

        public main_window()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.LoadData("Clients", dataGridView1);
            targetTable = "Clients";
            add_button.Enabled = true;
            change_button.Enabled = true;
        }

        private void программноеОбеспечениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.LoadData("Software", dataGridView1);
            targetTable = "Software";
            add_button.Enabled = true;
            change_button.Enabled = true;
        }

        private void создателиПрограммногоОбеспеченияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.LoadData("Software_creators", dataGridView1);
            targetTable = "Software_creators";
            add_button.Enabled = true;
            change_button.Enabled = true;
        }

        private void поддержкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.LoadData("Support", dataGridView1);
            targetTable = "Support";
            add_button.Enabled = true;
            change_button.Enabled = true;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            dataBase.Search(textBoxSearch.Text, targetTable, dataGridView1);
        }

        private void report_button_Click(object sender, EventArgs e)
        {
            rept reptForm = new rept();
            if (DialogResult.OK == reptForm.ShowDialog())
            {
                string selectedQuery = reptForm.Query;
                dataBase.LoadRept(selectedQuery, dataGridView1);
            }
        }

        private void постоянныеКлиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.LoadData("RegularClients", dataGridView1);
            targetTable = "RegularClients";
            add_button.Enabled = false;
            change_button.Enabled = false;
        }

        private void архивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.LoadData("SoftwareCreators_Archive", dataGridView1);
            targetTable = "SoftwareCreators_Archive";
            add_button.Enabled = false;
            change_button.Enabled = false;
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Проверяем, что строка выбрана
            {
                int target_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                dataBase.Delete(target_id, targetTable, dataGridView1);
            }
            else
            {
                MessageBox.Show("Выберите строку!");
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            add_object Add = new add_object(this);
            if (DialogResult.OK == Add.ShowDialog())
            {
                dataBase.ExecuteNonQuery(Add.mainQuery);
            }
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int selectId = Convert.ToInt32(selectedRow.Cells[0].Value);
            change_object Change = new change_object(this, selectId);
            if (DialogResult.OK == Change.ShowDialog())
            {
                dataBase.ExecuteNonQuery(Change.mainQuery);
            }
        }

        private void измененияСтоимостиПОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSoftwarePrice CHP = new ChangeSoftwarePrice(this);
            if(DialogResult.OK == CHP.ShowDialog())
            {
                MessageBox.Show($"Количество затронутых записей: {dataBase.UpdateSoftwarePrice(CHP.TargetId, CHP.price)}");
            }
        }

        private void количествоКлиентовКоторымПредстоитОбновитьУказанноеПОВБлижайшиеДваМесяцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Get_ClientId get = new Get_ClientId(this);
            if(DialogResult.OK == get.ShowDialog())
            {
                MessageBox.Show($"Количество клиентов: {dataBase.CountClientsForUpdate(get.clientId)}");
            }
            
        }
    }
}
