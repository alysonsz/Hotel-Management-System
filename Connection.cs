using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hotel_Management_System
{
    internal class Connection
    {
        public string connect = "SERVER = localhost; DATABASE = hotel; UID = root; PWD = ; PORT = ;"; //string de conexão
        public MySqlConnection sqlConnector = null; //variável que carrega conexão
        public void openConnection()
        {
            try
            {
                sqlConnector = new MySqlConnection(connect);
                sqlConnector.Open();
            }
            catch (Exception except)
            {
                MessageBox.Show("Server Error: " + except.Message);
            }
        }
        public void closedConnection()
        {
            try
            {
                sqlConnector = new MySqlConnection(connect);
                sqlConnector.Close();
            }
            catch (Exception except)
            {
                MessageBox.Show("Server Error: " + except.Message);
            }
            
        }
    }
}
