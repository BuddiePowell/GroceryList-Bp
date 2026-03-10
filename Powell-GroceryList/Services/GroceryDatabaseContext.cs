using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Powell_GroceryList.Services
{
    public class GroceryDatabaseContext
    {
        private String _connectionString;

        public GroceryDatabaseContext(String connectionString)
        {
            _connectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            _connectionString = "sever=introduction-to-databases.mysql.database.azure.com;port=3306;database=introduction-to-databases.mysql.database.azure.com;"
                    + "user=bpowell5;password=s2989121";

            return new MySqlConnection( _connectionString );

           
        }
        Public List<GroceryItem> GetAllGroceryitems() {
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
                groceryItem.id = dataReader.GetInt32("id");
                groceryItem.Name = dataReader.GetString("name");
                groceryItem.Store = new Store();
                groceryItem.Store.Id = dataReader.GetInt32("Storeid");

                groceryItems.Add( groceryItem );
            }

            dataReader.Close();
            connection.Close();

            return groceryItems;

        }
    }
}
