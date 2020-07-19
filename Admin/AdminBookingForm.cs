using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Booking3.Admin
{
    public partial class AdminBookingForm : UserControl
    {
        public AdminBookingForm()
        {
            InitializeComponent();
        }

        private void AdminBookingForm_Load(object sender, EventArgs e)
        {
            List<string> hotels_list = SQLClass.Select(
                "SELECT  booking.room_id, booking.user, booking.dateFrom, " +
                        "booking.dateTo, room.name, hotels.name" +
                " FROM booking" +
                    " JOIN room ON room.id = booking.room_id" +
                    " JOIN " + SQLClass.HOTELS + " hotels ON hotels.id = room.hotel_id" +
                " ORDER BY booking.dateFrom");

            panel2.Controls.Clear();
            int y = 15;
            for (int i = 0; i < hotels_list.Count; i += 6)
            {
                #region Пользователь
                Label lbl = new Label();
                lbl.Location = new Point(0, y);
                lbl.Size = new Size(200, 30);
                lbl.Text = hotels_list[i + 1];
                lbl.Tag = hotels_list[i];
                lbl.AccessibleName = hotels_list[i + 2];
                lbl.AccessibleDescription = hotels_list[i + 3];
                panel2.Controls.Add(lbl);
                #endregion

                #region Даты
                Label lbl2 = new Label();
                lbl2.Location = new Point(200, y);
                lbl2.Size = new Size(100, 30);
                lbl2.Text = hotels_list[i + 2];
                panel2.Controls.Add(lbl2);

                Label lbl3 = new Label();
                lbl3.Location = new Point(300, y);
                lbl3.Size = new Size(100, 30);
                lbl3.Text = hotels_list[i + 3];
                panel2.Controls.Add(lbl3);
                #endregion

                #region Номера
                Label lbl4 = new Label();
                lbl4.Location = new Point(400, y);
                lbl4.Size = new Size(200, 30);
                lbl4.Text = hotels_list[i + 4];
                panel2.Controls.Add(lbl4);

                Label lbl5 = new Label();
                lbl5.Location = new Point(600, y);
                lbl5.Size = new Size(200, 30);
                lbl5.Text = hotels_list[i + 5];
                panel2.Controls.Add(lbl5);
                #endregion

                Button btn = new Button();
                btn.Text = "Удалить";
                btn.Location = new Point(800, y);
                btn.Size = new Size(100, 30);
                btn.Click += new EventHandler(DeleteBooking);
                panel2.Controls.Add(btn);

                y += 30;
            }
        }


        private void DeleteBooking(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int y = btn.Location.Y;

            foreach (Control control in panel2.Controls)
            {
                if (control.Location == new Point(0, y))
                {
                    SQLClass.Update(
                        "DELETE FROM booking" +
                        " WHERE user = '" + control.Text + "'" +
                        " AND room_id = '" + control.Tag.ToString() + "'" +
                        " AND dateFrom = '" + Convert.ToDateTime(control.AccessibleName).ToString("yyyy-MM-dd") + "'" +
                        " AND dateTo = '" + Convert.ToDateTime(control.AccessibleDescription).ToString("yyyy-MM-dd") + "'");

                    AdminBookingForm_Load(sender, e);
                    return;
                }
            }
        }
    }
}
