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
    public partial class ChangeSoftwarePrice : Form
    {
        public main_window parentForm;
        public decimal price = 0;
        public int TargetId;
        public ChangeSoftwarePrice(main_window main)
        {
            InitializeComponent();
            parentForm = main;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangeSoftwarePrice_Load(object sender, EventArgs e)
        {
            List<string> SoftwareCreators = parentForm.dataBase.SearchSoftwareCreators();
            comboBox1.Items.Clear();
            foreach (var item in SoftwareCreators)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ExtractId(string comboBoxValue)
            {
                return string.IsNullOrEmpty(comboBoxValue) ? "" : comboBoxValue.Split(':')[0].Trim();
            }

            TargetId = Convert.ToInt32(ExtractId(comboBox1.SelectedItem?.ToString()));
            price = Convert.ToDecimal(textBox1.Text);
        }
    }
}
