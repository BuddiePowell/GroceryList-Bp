using MySql.Data.MySqlClient;
using Powell_GroceryList.Models;
using System;
using System.Collections.Generic;

namespace Powell_GroceryList.Services;

public class GroceryDatabaseContext
{
    private string _connectionString;

    public GroceryDatabaseContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public MySqlConnection GetConnection()
    {

        return new MySqlConnection(_connectionString);
    }

    public void AddGroceryItem(GroceryItem groceryItem)
    {
        MySqlConnection connection;
        MySqlCommand sqlCommand;

        connection = GetConnection();
        connection.Open();

        sqlCommand = new MySqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "INSERT INTO GROCERY_ITEM VALUES(NULL, @Name, @StoreId)";
        sqlCommand.Parameters.AddWithValue("@Name", groceryItem.Name);
        sqlCommand.Parameters.AddWithValue("@StoreId", groceryItem.StoreId);

        sqlCommand.ExecuteNonQuery();

        connection.Close();
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

            groceryItem.Id = dataReader.GetInt32("Id");
            groceryItem.Name = dataReader.GetString("Name");

            groceryItem.Store = new Store();
            groceryItem.StoreId = dataReader.GetInt32("StoreId");

            groceryItems.Add(groceryItem);
        }

        dataReader.Close();
        connection.Close();

        return groceryItems;
    }

    public List<Store> GetAllStores()
    {
        List<Store> stores = new List<Store>();

        MySqlConnection connection;
        MySqlCommand sqlCommand;
        MySqlDataReader dataReader;

        connection = GetConnection();
        connection.Open();

        sqlCommand = new MySqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM STORE";

        dataReader = sqlCommand.ExecuteReader();

        while (dataReader.Read())
        {
            Store store = new Store();

            store.Id = dataReader.GetInt32("Id");
            store.Name = dataReader.GetString("Name");
            store.Address = dataReader.GetString("Address");
            store.City = dataReader.GetString("City");
            store.State = dataReader.GetString("State");
            store.PhoneNumber = dataReader.GetString("PhoneNumber");

            stores.Add(store);
        }
        dataReader.Close();
        connection.Close();

        return stores;
    }
    }
    
        