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
    public partial class RoomForm : UserControl
    {
        string id = "";
        int qty = 0;

        public RoomForm(string RoomId)
        {
            id = RoomId;

            InitializeComponent();

            List<string> room_data = SQLClass.Select(
                "SELECT hotel, name, price, image, quantity FROM room WHERE id = " + RoomId);

            Text = room_data[0] + ": " + room_data[1];
            qty = Convert.ToInt32(room_data[4]);
            label2.Text = room_data[1];
            label4.Text = room_data[0];
            label6.Text = room_data[2];

            try
            {
                pictureBox1.Load("../../Pictures/" + room_data[3]);
            }
            catch (Exception) { }
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Провера ошибок
            if (MainForm.Login == "")
            {
                MessageBox.Show("Вы не авторизованы");
                return;
            }

            DateTime dt = dateTimePicker1.Value;
            while (dt <= dateTimePicker2.Value.AddDays(0.5))
            {
                List<string> existBooking = SQLClass.Select("SELECT COUNT(*) FROM booking " +
                    "WHERE dateFrom <= '" + dt.ToString("yyyy-MM-dd") + "'" +
                    "AND dateTo >= '" + dt.ToString("yyyy-MM-dd") + "'");

                if (Convert.ToInt32(existBooking[0]) >= qty)
                {
                    MessageBox.Show("Все забронировано. Выберите другие даты!");
                    return;
                }

                dt = dt.AddDays(1);
            }
            #endregion

            SQLClass.Update("INSERT INTO booking(user, datefrom, dateto, room_id) VALUES(" +
                "'" + MainForm.Login + "', " +
                "'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'," +
                "'" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'," +
                id + ")");
            MessageBox.Show("Успешно");
        }
    }
}
