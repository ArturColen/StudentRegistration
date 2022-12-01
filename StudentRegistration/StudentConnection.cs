using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace StudentRegistration
{
    internal class StudentConnection
    {
        MySqlConnection con;

        // Method for connecting the form to the database
        public void ConnectDB()
        {
            try
            {
                con = new MySqlConnection("Persist Security info = false; server = localhost;" + "database = school; user = root; pwd = ;");
                con.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method to execute CRUD commands
        public void executeCommands(String sql)
        {
            try
            {
                ConnectDB();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        // Method to execute the database query
        public DataTable executeQuery(String sql)
        {
            try
            {
                ConnectDB();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}