using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace DataAccess
{
    public class Data_Access_tools
    {
        public static void Initialize_Database()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=DateRmb_7db.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT EXISTS Data" +
                                      "(ID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                      "Month INT, Day INT, Name TEXT, Description TEXT);";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }

        public static void Add_Data(int Month, int Day, string Name, string Description)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=DateRmb_7db.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Data (Month,Day,Name,Description)" +
                                            "VALUES (@myMonth,@myDay,@myName,@myDescription);";
                insertCommand.Parameters.AddWithValue("@myMonth", Month);
                insertCommand.Parameters.AddWithValue("@myDay", Day);
                insertCommand.Parameters.AddWithValue("@myName", Name);
                insertCommand.Parameters.AddWithValue("@myDescription", Description);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        //Read database and return a List<date> already order by Days left
        public static List<Date> GetData()
        {
            List<Date> entries = new List<Date>();
            int day;
            int month;
            string name;
            string description;
            using (SqliteConnection db = new SqliteConnection("Filename=DateRmb_7db.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT Month,Day,Name,Description FROM Data", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    month = query.GetInt32(0);
                    day = query.GetInt32(1);
                    name = query.GetString(2);
                    description = query.GetString(3);
                    Date my_date = new Date(month, day, name, description);
                    entries.Add(my_date);
                }
                db.Close();
            }
            entries.Sort((x, y) => x.Days_left_int.CompareTo(y.Days_left_int));
            return entries;
        }

        public static int Get_ID(string Name)
        {
            int ID=0;
            using (SqliteConnection db = new SqliteConnection("Filename=DateRmb_7db.db"))
            {          
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT ID FROM Data WHERE Name=@myName", db);
                selectCommand.Parameters.AddWithValue("@myName", Name);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {                    
                    ID = query.GetInt32(0);                   
                }
                db.Close();
            }
            return ID;    
        }

        public static void DeleteData(string Name)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=DateRmb_7db.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "DELETE FROM Data WHERE Name=@myName";
                insertCommand.Parameters.AddWithValue("@myName", Name);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public static void EditData(int id, int Month, int Day, string Name, string Description)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=DateRmb_7db.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("UPDATE Data SET Name=@myName, Day=@myDay, Month=@myMonth, Description=@myDescription WHERE ID=@myid", db);
                selectCommand.Parameters.AddWithValue("@myid", id);
                selectCommand.Parameters.AddWithValue("@myMonth", Month);
                selectCommand.Parameters.AddWithValue("@myDay", Day);
                selectCommand.Parameters.AddWithValue("@myName", Name);
                selectCommand.Parameters.AddWithValue("@myDescription", Description);
                SqliteDataReader query = selectCommand.ExecuteReader();                
                db.Close();
            }
        }
    }
}
