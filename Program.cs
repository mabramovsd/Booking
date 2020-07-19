using System;
using System.IO;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Booking3
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            { 
                SQLClass.CONN = new MySqlConnection(SQLClass.CONNECTION_STRING);
                SQLClass.CONN.Open();
            }
            catch (Exception ex)
            {
                if (!File.Exists(Path.GetTempPath() + "/booking.txt"))
                    File.Create(Path.GetTempPath() + "/booking.txt");

                File.AppendAllText(Path.GetTempPath() + "/booking.txt",
                    "Ошибка" + Environment.NewLine +
                    DateTime.Now.ToString() + Environment.NewLine +
                    ex.Message + Environment.NewLine + Environment.NewLine);
                MessageBox.Show("Ошибка");
            }

            Application.Run(new MainForm());

            SQLClass.CONN.Close();
        }
    }
}
