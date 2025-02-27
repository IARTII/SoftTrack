using System;
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
    public partial class Get_ClientId : Form
    {
        main_window parent_form;
        public int clientId = 0;
        public Get_ClientId(main_window main)
        {
            InitializeComponent();
            parent_form = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ExtractId(string comboBoxValue)
            {
                return string.IsNullOrEmpty(comboBoxValue) ? "" : comboBoxValue.Split(':')[0].Trim();
            }

            clientId = Convert.ToInt32(ExtractId(comboBox1.SelectedItem?.ToString()));
        }

        private void Get_ClientId_Load(object sender, EventArgs e)
        {
            List<string> Software = parent_form.dataBase.SearchSoftware();
            comboBox1.Items.Clear();
            foreach (var item in Software)
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            comboBox1.Text = "";
        }
    }
}
