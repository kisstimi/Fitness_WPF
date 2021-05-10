using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = "SERVER=localhost;DATABASE=fitnessterem;UID=root;PASSWORD=21Ladygaga18;";

        public MainWindow()
        {
            InitializeComponent();
            disp_data();
        }

        public void disp_data()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from kliensek", connection);
            connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();

            dtGrid.DataContext = dt;
        }



        private void insert_btn_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string insertQuery = "INSERT INTO kliensek (nev,telefon,email,is_deleted,photo,inserted_date,szemelyi_szam,cim,vonalkod,megjegyzesek) VALUES('" + textbox1.Text + "','" + textbox2.Text + "','" + textbox3.Text + "','" + textbox4.Text + "','" + textbox5.Text + "','" + textbox6.Text + "','" + textbox7.Text + "','" + textbox8.Text + "','" + textbox9.Text + "','" + textbox10.Text + "')";
            MySqlCommand cmd = new MySqlCommand(insertQuery, connection);

            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Inserted");
                }
                else
                {
                    MessageBox.Show("Data not inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();


        }
    }
}
