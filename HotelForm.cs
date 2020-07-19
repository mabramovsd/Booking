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
    public partial class HotelForm : Form
    {
        string HotelName;
        string id;

        public HotelForm(string hotel_id)
        {
            InitializeComponent();

            #region Видимость админских компонент
            OpinionPanel.Visible = (MainForm.Login != "");
            button1.Visible = MainForm.IsAdmin;
            textBox2.ReadOnly = !MainForm.IsAdmin;
            textBox2.Enabled = MainForm.IsAdmin;
            textBox3.ReadOnly = !MainForm.IsAdmin;
            textBox3.Enabled = MainForm.IsAdmin;
            #endregion


            List<string> hotels = SQLClass.Select(
                "SELECT Name, City, Image, Rating, id, description FROM " + SQLClass.HOTELS +
                " WHERE id = '" + hotel_id + "'");

            HotelName = hotels[0];
            id = hotel_id;
            try
            {
                pictureBox1.Load("../../Pictures/" + hotels[2]);
            }
            catch (Exception) { }

            Text = hotels[0];
            textBox2.Text = hotels[0];
            textBox3.Text = hotels[5];

            #region Рисование звезд
            int x = 275;
            for (int i = 0; i < Convert.ToInt32(hotels[3]); i++)
            {
                PictureBox box = new PictureBox();
                box.Location = new Point(x, 80);
                box.Load("../../Pictures/star.png");
                box.Size = new Size(33, 33);
                box.SizeMode = PictureBoxSizeMode.StretchImage;
                InfoPanel.Controls.Add(box);
                x += 40;
            }
            #endregion

            #region Номера
            List<string> rooms = SQLClass.Select("SELECT id, name, price, image, quantity FROM room WHERE hotel_id = " + id);

            x = 15;
            HotelsPanel.Controls.Clear();
            for (int i = 0; i < rooms.Count; i += 5)
            {
                PictureBox pb = new PictureBox();
                try
                {
                    pb.Load("../../Pictures/" + rooms[i + 3]);
                }
                catch (Exception) { }
                pb.Location = new Point(x, 10);
                pb.Size = new Size(190, 120);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = rooms[i];
                pb.Click += new EventHandler(pictureBox7_Click);
                HotelsPanel.Controls.Add(pb);

                Label lbl = new Label();
                lbl.Font = new Font("Arial", 10);
                lbl.Location = new Point(x, 140);
                lbl.Size = new Size(200, 30);
                lbl.Text = rooms[i + 1] + " (" + rooms[i+2] +")";
                lbl.Tag = rooms[i];
                lbl.Click += new EventHandler(label3_Click);
                HotelsPanel.Controls.Add(lbl);

                if (MainForm.IsAdmin)
                {
                    TextBox lbl2 = new TextBox();
                    lbl2.Font = new Font("Arial", 10);
                    lbl2.Location = new Point(x, 170);
                    lbl2.Size = new Size(200, 30);
                    lbl2.Text = rooms[i + 4] + " штук";
                    lbl2.Tag = rooms[i];
                    lbl2.KeyDown += new KeyEventHandler(textBox4_KeyDown);
                    HotelsPanel.Controls.Add(lbl2);
                }

                x += 205;
            }
            #endregion
        }

        private void HotelForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            RoomForm rf = new RoomForm(pb.Tag.ToString());
            rf.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Label pb = (Label)sender;
            RoomForm rf = new RoomForm(pb.Tag.ToString());
            rf.Show();
        }

        private void OpinionPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OpinionCLick(object sender, EventArgs e)
        {
            SQLClass.Update("INSERT INTO rating(user, hotel_id, rate, comment) VALUES(" +
                "'" + MainForm.Login + "', " +
                "'" + id + "', " +
                "'" + numericUpDown1.Value.ToString() + "', " +
                "'" + textBox1.Text + "')");
            MessageBox.Show("Спасибо");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLClass.Update(
                "UPDATE  " + SQLClass.HOTELS + 
                " SET name = '" + textBox2.Text + "', " +
                " description = '" + textBox3.Text + "'" +
                " WHERE id = '" + id + "'");
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (e.KeyCode == Keys.Enter)
            {
                SQLClass.Update(
                    "UPDATE room" +
                    " SET quantity = '" + tb.Text.Replace("штук", "") + "'" +
                    " WHERE id = '" + tb.Tag.ToString() + "'");
            }
        }
    }
}
