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
    public partial class MainForm : Form
    {
        public static string Login = "";
        public static bool IsAdmin = false;



        public MainForm()
        {
            InitializeComponent();
        }
        
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            HotelList hotelList = new HotelList();
            hotelList.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(hotelList);


            List<string> cities = SQLClass.Select("SELECT DISTINCT name FROM cities ORDER BY name");
            foreach (string city in cities)
            {
                TreeNode node = new TreeNode(city);
                treeView1.Nodes[0].Nodes.Add(node);


                List<string> hotels = SQLClass.Select(
                    "SELECT DISTINCT name, id FROM hotels" +
                    " WHERE city='" + node.Text + "' ORDER BY name");
                for (int i = 0; i < hotels.Count; i += 2)
                {
                    TreeNode node2 = new TreeNode(hotels[i]);
                    node2.Tag = hotels[i + 1];
                    node.Nodes.Add(node2);

                    List<string> rooms = SQLClass.Select(
                        "SELECT DISTINCT name, id FROM room" +
                        " WHERE hotel_id='" + node2.Tag.ToString() + "' ORDER BY name");
                    for (int j = 0; j < rooms.Count; j += 2)
                    {
                        TreeNode node3 = new TreeNode(rooms[j]);
                        node3.Tag = rooms[j + 1];
                        node2.Nodes.Add(node3);
                    }
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            AdminForm af = new AdminForm();

            Controls.Clear();
            Controls.Add(af);
            af.Dock = DockStyle.Fill;
        }

        private void LoginClick(object sender, EventArgs e)
        {
            //Вход
            if (Login == "")
            {
                List<string> user_data = SQLClass.Select(
                    "SELECT admin FROM users WHERE Login = '" + LoginTextBox.Text +
                    "' AND Password = '" + PasswordTextBox.Text + "'");

                //Авторизация успешна
                if (user_data.Count > 0)
                {
                    //Глобальные переменные
                    Login = LoginTextBox.Text;
                    IsAdmin = (user_data[0] == "1");

                    //Компоненты на форме
                    AuthPanel.Controls.Clear();
                    AdminButton.Visible = (user_data[0] == "1");
                    AuthPanel.Controls.Add(AdminButton);

                    AuthPanel.Controls.Add(HelloLabel);
                    HelloLabel.Text = "Привет, " + Login;

                    AuthPanel.Controls.Add(LoginButton);
                    LoginButton.Text = "Выход";

                    AuthPanel.Controls.Add(AccountButton);
                    AccountButton.Visible = true;
                }
                else
                {
                    user_data = SQLClass.Select(
                        "SELECT * FROM users WHERE Login = '" + LoginTextBox.Text + "'");

                    if (user_data.Count > 0)
                        MessageBox.Show("Неправильный пароль");
                    else
                        MessageBox.Show("Вы не зарегистрированы");
                }
            }
            //Выход
            else
            {
                //Глобальные переменные
                Login = "";
                IsAdmin = false;

                //Компоненты на форме
                AuthPanel.Controls.Clear();
                AuthPanel.Controls.Add(LoginLabel);
                AuthPanel.Controls.Add(LoginTextBox);
                AuthPanel.Controls.Add(PasswordLabel);
                AuthPanel.Controls.Add(PasswordTextBox);
                AuthPanel.Controls.Add(LoginButton);
                LoginButton.Text = "Вход";
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void RatingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AccountButton_Click(object sender, EventArgs e)
        {
            AccountForm af = new AccountForm();
            af.ShowDialog();

            HelloLabel.Text = "Привет, " + Login;
        }

        /// <summary>
        /// Скрытие админского узла
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsAdmin && treeView1.Nodes.Count == 1)
            {
                TreeNode node = new TreeNode("Админка");
                treeView1.Nodes.Add(node);


                TreeNode node2 = new TreeNode("Гостиницы");
                node.Nodes.Add(node2);
                TreeNode node3 = new TreeNode("Комнаты");
                node.Nodes.Add(node3);
                TreeNode node4 = new TreeNode("Пользователи");
                node.Nodes.Add(node4);
                TreeNode node5 = new TreeNode("Бронирования");
                node.Nodes.Add(node5);
                TreeNode node6 = new TreeNode("Ошибки");
                node.Nodes.Add(node6);
            }
            else if (!IsAdmin && treeView1.Nodes.Count > 1)
            {
                treeView1.Nodes.RemoveAt(1);
            }
        }

        /// <summary>
        /// Выбор узла дерева
        /// </summary>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            #region Выбран город
            if (e.Node.Level == 0 && e.Node.Text == "Города" ||
                e.Node.Level == 1 && e.Node.Parent.Text == "Города")
            {
                HotelList listUC = new HotelList();
                listUC.Dock = DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(listUC);
            }
            #endregion

            #region Выбрана гостиница
            else if (e.Node.Level == 2 && 
                e.Node.Parent.Parent.Text == "Города")
            {
                HotelForm listUC = new HotelForm(e.Node.Tag.ToString());
                listUC.Dock = DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(listUC);
            }
            #endregion

            #region Выбрана комната
            else if (e.Node.Level == 3 && 
                e.Node.Parent.Parent.Parent.Text == "Города")
            {
                RoomForm listUC = new RoomForm(e.Node.Tag.ToString());
                listUC.Dock = DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(listUC);
            }
            #endregion

            #region Выбрана админка
            else if (e.Node.Level == 0 && e.Node.Text == "Админка")
            {
                AdminForm listUC = new AdminForm();
                listUC.Dock = DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(listUC);
            }
            else if (e.Node.Level == 1 &&
                e.Node.Parent.Text == "Админка" &&
                e.Node.Text == "Гостиницы")
            {
                AdminHotelsForm listUC = new AdminHotelsForm();
                listUC.Dock = DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(listUC);
            }
            else if (e.Node.Level == 1 &&
                e.Node.Parent.Text == "Админка" &&
                e.Node.Text == "Комнаты")
            {
                AdminRoomsForm listUC = new AdminRoomsForm();
                listUC.Dock = DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(listUC);
            }
            else if (e.Node.Level == 1 &&
                e.Node.Parent.Text == "Админка" &&
                e.Node.Text == "Бронирования")
            {
                Admin.AdminBookingForm listUC = new Admin.AdminBookingForm();
                listUC.Dock = DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(listUC);
            }
            else if (e.Node.Level == 1 &&
                e.Node.Parent.Text == "Админка" &&
                e.Node.Text == "Ошибки")
            {
                Admin.AdminLogForm listUC = new Admin.AdminLogForm();
                listUC.Dock = DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(listUC);
            }
            else if (e.Node.Level == 1 &&
                e.Node.Parent.Text == "Админка" &&
                e.Node.Text == "Пользователи")
            {
                AdminUsersForm listUC = new AdminUsersForm();
                listUC.Dock = DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(listUC);
            }
            #endregion

        }
    }
}
