using MySql.Data.MySqlClient;
using Powell_GroceryList.Models;
using System;
using System.Collections.Generic;

namespace Powell_GroceryList.Database
{
    public class GroceryDatabaseContext
    {
        private string _connectionString;

        public GroceryDatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            _connectionString = "server=introduction-to-databases.mysql.database.azure.com;port=3306;database=introduction_to_databases;user=bpowell5;password=s2989121;";

            return new MySqlConnection(_connectionString);
        }

        public List<GroceryItem> GetAllGroceryItems()
        {
            List<GroceryItem> groceryItems = new List<GroceryItem>();

            MySqlConnection connection;
            MySqlCommand sqlCommand;
            MySqlDataReader dataReader;

            connection = GetConnection();
            connection.Open();

            sqlCommand = new MySqlCommand();
            sqlCommand.CommandText = "SELECT * FROM GROCERY_ITEM";
            sqlCommand.Connection = connection;

            dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                GroceryItem groceryItem = new GroceryItem();

                groceryItem.Id = dataReader.GetInt32("id");
                groceryItem.Name = dataReader.GetString("name");

                groceryItem.Store = new Store();
                groceryItem.Store.Id = dataReader.GetInt32("storeid");

                groceryItems.Add(groceryItem);
            }

            dataReader.Close();
            connection.Close();

            return groceryItems;
        }
    }
}