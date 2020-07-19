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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminHotelsForm af = new AdminHotelsForm();
            af.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminRoomsForm af = new AdminRoomsForm();
            af.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminUsersForm af = new AdminUsersForm();
            af.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin.AdminBookingForm af = new Admin.AdminBookingForm();
            af.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin.AdminLogForm af = new Admin.AdminLogForm();
            af.Show();
        }
    }
}
