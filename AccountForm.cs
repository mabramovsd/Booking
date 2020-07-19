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
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();

            List<string> cities = SQLClass.Select("SELECT DISTINCT Name FROM cities ORDER BY Name");
            CityComboBox.Items.Clear();
            CityComboBox.Items.Add("");
            foreach (string city in cities)
                CityComboBox.Items.Add(city);

            List<string> user_data = SQLClass.Select("SELECT login, name, city, age, password FROM users" +
                " WHERE login = '" + MainForm.Login + "'");

            if (user_data.Count > 0)
            {
                LoginTextBox.Text = user_data[0];
                textBox2.Text = user_data[1];
                textBox1.Text = user_data[3];
                PasswordTextBox.Text = user_data[4];

                //Выбор города
                for (int i = 0; i < CityComboBox.Items.Count; i++)
                {
                    if (CityComboBox.Items[i].ToString() == user_data[2])
                        CityComboBox.SelectedIndex = i;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region Проверка ошибок
            if (LoginTextBox.Text == "")
            {
                return;
            }

            List<string> existUser = SQLClass.Select(
                "SELECT * FROM users WHERE login = '" + LoginTextBox.Text + "'");
            if (existUser.Count > 0)
            {
                MessageBox.Show("Пользователь с таким логином существует");
                return;
            }
            #endregion

            SQLClass.Update("UPDATE users SET" +
                " name = '" + textBox2.Text + "'," +
                " city = '" + CityComboBox.Text + "'," +
                " age = '" + textBox1.Text + "'," +
                " login = '" + LoginTextBox.Text + "'," +
                " password = '" + PasswordTextBox.Text + "'" +
                " WHERE login = '" + MainForm.Login + "'");

            SQLClass.Update("UPDATE booking SET" +
                " user = '" + LoginTextBox.Text + "'" +
                " WHERE user = '" + MainForm.Login + "'");

            SQLClass.Update("UPDATE rating SET" +
                " user = '" + LoginTextBox.Text + "'" +
                " WHERE user = '" + MainForm.Login + "'");

            MainForm.Login = LoginTextBox.Text;
        }
    }
}
