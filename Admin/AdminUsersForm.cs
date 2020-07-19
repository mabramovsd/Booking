using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Booking3
{
    public partial class AdminUsersForm : UserControl
    {
        public AdminUsersForm()
        {
            InitializeComponent();

            List<string> cities = SQLClass.Select("SELECT DISTINCT Name FROM cities ORDER BY Name");
            CityComboBox.Items.Clear();
            CityComboBox.Items.Add("");
            foreach (string city in cities)
                CityComboBox.Items.Add(city);

            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            string command = "SELECT Login, Name, City, Age FROM Users WHERE 1";
            if (CityComboBox.Text != "")
                command += " AND city= '" + CityComboBox.Text + "'";
            if (AgeTextBox.Text != "")
                command += " AND age >= " + AgeTextBox.Text;

            command += " ORDER BY Login";

            List<string> users = SQLClass.Select(command);

            int y = 0;
            for (int i = 0; i < users.Count; i += 4)
            {
                Label lbl = new Label();
                lbl.Location = new Point(0, y);
                lbl.Size = new Size(100, 30);
                lbl.Text = users[i];
                panel2.Controls.Add(lbl);

                Label lbl2 = new Label();
                lbl2.Location = new Point(100, y);
                lbl2.Size = new Size(100, 30);
                lbl2.Text = users[i + 1];
                panel2.Controls.Add(lbl2);

                Label lbl3 = new Label();
                lbl3.Location = new Point(200, y);
                lbl3.Size = new Size(100, 30);
                lbl3.Text = users[i + 2];
                panel2.Controls.Add(lbl3);

                Label lbl4 = new Label();
                lbl4.Location = new Point(300, y);
                lbl4.Size = new Size(100, 30);
                lbl4.Text = users[i + 3];
                panel2.Controls.Add(lbl4);

                y += 30;
            }
        }

        private void AdminUsersForm_Load(object sender, EventArgs e)
        {

        }
    }
}
