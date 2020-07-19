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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            List<string> cities = SQLClass.Select("SELECT DISTINCT Name FROM cities ORDER BY Name");
            CityComboBox.Items.Clear();
            CityComboBox.Items.Add("");
            foreach (string city in cities)
                CityComboBox.Items.Add(city);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> exist = SQLClass.Select("SELECT Login FROM users WHERE login = '" + LoginTextBox.Text + "'");
            if (exist.Count > 0)
                MessageBox.Show("Вы уже зарегистрированы");
            else
                SQLClass.Update("INSERT INTO users(login, password, name, age, city) VALUES(" +
                    "'" + LoginTextBox.Text + "'," +
                    "'" + PasswordTextBox.Text + "'," +
                    "'" + textBox1.Text + "'," +
                    "'" + textBox2.Text + "'," +
                    "'" + CityComboBox.Text + "')");
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
