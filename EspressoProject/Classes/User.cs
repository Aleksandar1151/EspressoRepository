using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EspressoProject.Classes
{
    class User
    {

        public static List<string> GetNames()
        {
            List<string> resultList = new List<string>();

            try
            {

                String query = "SELECT * FROM nalozi;";
                MySqlCommand cmd = new MySqlCommand(query, MainWindow.dbConn);
                MainWindow.dbConn.Open();


                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    String result = reader["korisnicko_ime"].ToString();
                    resultList.Add(result);
                }

                MainWindow.dbConn.Close();


            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja robe.\nRazlog: " + ex.Message); }

            return resultList;
        }
    }
}
