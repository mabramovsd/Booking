using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Booking3
{
    public partial class HotelList : UserControl
    {
        public HotelList(/*string City = ""*/)
        {
            InitializeComponent();

            List<string> cities = SQLClass.Select(
                "SELECT DISTINCT Name FROM cities ORDER BY Name");
            CityComboBox.Items.Clear();
            CityComboBox.Items.Add("");
            foreach (string city in cities)
                CityComboBox.Items.Add(city);

            //Ищем город
            /*for (int i = 0; i < CityComboBox.Items.Count; i++)
            {
                if (CityComboBox.Items[i].ToString() == City)
                {
                    CityComboBox.SelectedIndex = i;
                }
            }*/

            Filter(null, null);
        }

        /// <summary>
        /// Открытие гостиницы
        /// </summary>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            HotelForm hf = new HotelForm(pb.Tag.ToString());
            Controls.Clear();
            Controls.Add(hf);
            hf.Dock = DockStyle.Fill;
            Filter(sender, e);
        }

        /// <summary>
        /// Открытие гостиницы
        /// </summary>
        private void label4_Click(object sender, EventArgs e)
        {
            Label pb = (Label)sender;
            HotelForm hf = new HotelForm(pb.Tag.ToString());
            Controls.Clear();
            Controls.Add(hf);
            hf.Dock = DockStyle.Fill;
            Filter(sender, e);
        }


        /// <summary>
        /// ФИльтр
        /// </summary>
        private void Filter(object sender, EventArgs e)
        {
            HotelsPanel.Controls.Clear();
            string command = "SELECT id, Name, City, Image, Rating FROM  " + SQLClass.HOTELS + "  WHERE 1";
            if (CityComboBox.Text != "")
                command += " AND city = '" + CityComboBox.Text + "'";
            if (RatingComboBox.Text != "")
                command += " AND Rating >= " + RatingComboBox.Text;

            List<string> hotels = SQLClass.Select(command);

            int x = 15;
            for (int i = 0; i < hotels.Count; i += 5)
            {
                PictureBox pb = new PictureBox();
                try
                {
                    pb.Load("../../Pictures/" + hotels[i + 3]);
                }
                catch (Exception) { }
                pb.Location = new Point(x, 10);
                pb.Size = new Size(190, 120);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = hotels[i];
                pb.Click += new EventHandler(pictureBox1_Click);
                HotelsPanel.Controls.Add(pb);

                Label lbl = new Label();
                lbl.Location = new Point(x, 140);
                lbl.Size = new Size(200, 30);
                lbl.Text = hotels[i + 1];
                lbl.Tag = hotels[i];
                lbl.Click += new EventHandler(label4_Click);
                HotelsPanel.Controls.Add(lbl);

                x += 205;
            }
        }


        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (FilterPanel.Size.Height < 50)
                FilterPanel.Size = new Size(FilterPanel.Size.Width, 120);
            else
                FilterPanel.Size = new Size(FilterPanel.Size.Width, FilterButton.Size.Height);
        }
    }
}
