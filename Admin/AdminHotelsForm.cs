using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Booking3
{
    public partial class AdminHotelsForm : UserControl
    {
        public AdminHotelsForm()
        {
            InitializeComponent();
        }

        string address = "";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                address = openFileDialog1.FileName;
                pictureBox1.Load(address);

                try
                {
                    System.IO.File.Copy(address, "../../Pictures/" + System.IO.Path.GetFileName(address));
                }
                catch (Exception) { }

                address = System.IO.Path.GetFileName(address);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLClass.Update(
                "INSERT INTO  " + SQLClass.HOTELS + " (Name, City, Rating, Image)" +
                " VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + 
                                textBox3.Text + "', '" + address + "')");
            MessageBox.Show("Сохранено");
        }

        private void AdminHotelsForm_Load(object sender, EventArgs e)
        {
            List<string> hotels_list = SQLClass.Select("SELECT Name, City, Rating FROM " + SQLClass.HOTELS);

            panel2.Controls.Clear();
            int y = 15;
            for (int i = 0; i < hotels_list.Count; i += 3)
            {
                Label lbl = new Label();
                lbl.Location = new Point(0, y);
                lbl.Size = new Size(200, 30);
                lbl.Text = hotels_list[i];
                panel2.Controls.Add(lbl);

                Label lbl2 = new Label();
                lbl2.Location = new Point(200, y);
                lbl2.Size = new Size(100, 30);
                lbl2.Text = hotels_list[i + 1];
                panel2.Controls.Add(lbl2);

                Label lbl3 = new Label();
                lbl3.Location = new Point(300, y);
                lbl3.Size = new Size(100, 30);
                lbl3.Text = hotels_list[i + 2];
                panel2.Controls.Add(lbl3);

                Button btn = new Button();
                btn.Text = "Удалить";
                btn.Location = new Point(400, y);
                btn.Size = new Size(100, 30);
                btn.Click += new EventHandler(DeleteHotel);
                panel2.Controls.Add(btn);

                y += 30;
            }
        }

        private void DeleteHotel(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int y = btn.Location.Y;

            foreach (Control control in panel2.Controls)
            {
                if (control.Location == new Point(0, y))
                {
                    SQLClass.Update(
                        "DELETE FROM " + SQLClass.HOTELS + " WHERE Name = '" + control.Text + "'");
                    
                    AdminHotelsForm_Load(sender, e);
                    return;
                }
            }
        }
    }
}
