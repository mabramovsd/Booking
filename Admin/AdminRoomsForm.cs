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
    public partial class AdminRoomsForm : UserControl
    {
        public AdminRoomsForm()
        {
            InitializeComponent();

            List<string> hotels_list = SQLClass.Select("SELECT Name, city, id FROM " + SQLClass.HOTELS);

            comboBox1.Items.Clear();
            for (int i = 0; i < hotels_list.Count; i += 3)
            {
                comboBox1.Items.Add(hotels_list[i] + /*" " + hotels_list[i + 1] +*/ " (" + hotels_list[i + 2] + ")");
            }
        }

        string address = "";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                address = openFileDialog1.FileName;
                pictureBox1.Load(address);
                
                System.IO.File.Copy(address, "../../Pictures/" + System.IO.Path.GetFileName(address));
                address = System.IO.Path.GetFileName(address);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] parts = comboBox1.Text.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            SQLClass.Update(
                "INSERT INTO room(Name, hotel, hotel_id, price, Image)" +
                " VALUES('" + textBox1.Text + "', '" + parts[0] + "', '" + parts[1] + "', '" +
                                textBox3.Text + "', '" + address + "')");
            MessageBox.Show("Сохранено");
            AdminRoomsForm_Load(sender, e);
        }

        private void AdminRoomsForm_Load(object sender, EventArgs e)
        {
            List<string> rooms_list = SQLClass.Select("SELECT Name, hotel, price, id FROM room");

            panel2.Controls.Clear();
            int y = 15;
            for (int i = 0; i < rooms_list.Count; i += 4)
            {
                Label lbl = new Label();
                lbl.Location = new Point(0, y);
                lbl.Size = new Size(200, 30);
                lbl.Text = rooms_list[i];
                lbl.Tag = rooms_list[i + 3];
                panel2.Controls.Add(lbl);

                Label lbl2 = new Label();
                lbl2.Location = new Point(200, y);
                lbl2.Size = new Size(200, 30);
                lbl2.Text = rooms_list[i + 1];
                panel2.Controls.Add(lbl2);

                Label lbl3 = new Label();
                lbl3.Location = new Point(400, y);
                lbl3.Size = new Size(100, 30);
                lbl3.Text = rooms_list[i + 2];
                panel2.Controls.Add(lbl3);

                Button btn = new Button();
                btn.Text = "Удалить";
                btn.Location = new Point(500, y);
                btn.Size = new Size(100, 30);
                btn.Click += new EventHandler(DeleteRoom);
                panel2.Controls.Add(btn);

                y += 30;
            }
        }

        private void DeleteRoom(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int y = btn.Location.Y;

            foreach (Control control in panel2.Controls)
            {
                if (control.Location == new Point(0, y))
                {
                    SQLClass.Update(
                        "DELETE FROM room WHERE id = '" + control.Tag.ToString() + "'");

                    AdminRoomsForm_Load(sender, e);
                    return;
                }
            }
        }
    }
}