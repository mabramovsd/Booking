using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Booking3.Admin
{
    public partial class AdminLogForm : Form
    {
        public AdminLogForm()
        {
            InitializeComponent();
        }

        private void AdminLogForm_Load(object sender, EventArgs e)
        {
            string Text = File.ReadAllText(Path.GetTempPath() + "/booking.txt");

            string[] lines = Text.Split(new string[] { "Ошибка" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string error in lines)
            {
                string[] parts = error.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                dataGridView1.Rows.Add(parts);
            }
        }
    }
}
