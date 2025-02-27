using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftTrack
{
    public partial class rept : Form
    {
        public string Query { get; private set; } = "";

        public rept()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Query = "SELECT c.id, c.Name, c.[E-mail], c.Phone, c.software_id, c.support_end FROM Clients c WHERE c.support_end <= GETDATE();";
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Query = "SELECT s.id, s.Name, s.category, s.[license type], COUNT(c.software_id) AS SalesCount, SUM(s.Price) AS TotalRevenue FROM Software s LEFT JOIN Clients c ON s.id = c.software_id GROUP BY s.id, s.Name, s.category, s.[license type];";
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Query = "SELECT s.id, s.Name, COUNT(c.software_id) AS SalesCount, sc.id AS CreatorID, sc.Name AS CreatorName, (SELECT COUNT(*) FROM Software WHERE creator_id = sc.id) AS SoftwareCount FROM Software s LEFT JOIN Clients c ON s.id = c.software_id LEFT JOIN Software_creators sc ON s.creator_id = sc.id GROUP BY s.id, s.Name, sc.id, sc.Name;";
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Query = "SELECT id, software_id, DATEDIFF(DAY, sale_date, support_end) AS DaysUntilUpdate FROM Clients WHERE support_end IS NOT NULL AND sale_date IS NOT NULL;";
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
