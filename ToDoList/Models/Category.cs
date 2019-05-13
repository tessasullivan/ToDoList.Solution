using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Category
  {
    private string _name;
    private int _id;
    private List<Item> _items;

    public Category(string categoryName, int id = 0)
    {
        _name = categoryName;
        _id = id;
        _items = new List<Item>{};
    }
    public string GetName()
    {
        return _name;
    }
    public int GetId()
    {
        return _id;
    }
    public override int GetHashCode()
    {
        return this.GetId().GetHashCode();
    }
    // public List<Item> GetItems()
    // {
    //     return _items;
    // }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }
    public static Category Find(int id)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM categories WHERE id = (@searchId);";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = id;
        cmd.Parameters.Add(searchId);
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int CategoryId = 0;
        string CategoryName = "";
        while(rdr.Read())
        {
        CategoryId = rdr.GetInt32(0);
        CategoryName = rdr.GetString(1);
        }
        Category newCategory = new Category(CategoryName, CategoryId);
        conn.Close();
        if (conn != null)
        {
        conn.Dispose();
        }
        return newCategory;
    }
    public static void ClearAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM categories;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }
    public void Delete()
    {

    }
    public static List<Category> GetAll()
    {
        List<Category> allCategories = new List<Category>{};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM categories;";
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while (rdr.Read())
        {
            int categoryId = rdr.GetInt32(0);
            string categoryName = rdr.GetString(1);
            Category newCategory = new Category(categoryName, categoryId);
            allCategories.Add(newCategory);
        }
        conn.Close();
        if (conn != null)
        {
        conn.Dispose();
        }
        return allCategories;
    } 
    public override bool Equals(System.Object otherCategory)
    {
        if (!(otherCategory is Category))
        {
        return false;
        }
        else
        {
        Category newCategory= (Category) otherCategory;
        bool idEquality = this.GetId().Equals(newCategory.GetId());
        bool nameEquality = this.GetName().Equals(newCategory.GetName());
        return (idEquality && nameEquality);
        }
    }
    public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO categories (name) VALUES (@name);";
        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@name";
        name.Value = this._name;
        cmd.Parameters.Add(name);
        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
        conn.Dispose();
        }
    }

    public List<Item> GetItems()
    {
        List<Item> allItems = new List<Item> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT items.* FROM categories
            JOIN categories_items ON (categories.id = categories_items.category_id)
            JOIN items ON (categories_items.item_id = items.id)
            WHERE categories.id = @CategoryId;";
        MySqlParameter categoryIdParameter = new MySqlParameter();
        categoryIdParameter.ParameterName = "@CategoryId";
        categoryIdParameter.Value = _id;
        cmd.Parameters.Add(categoryIdParameter);
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        List<int> itemIds = new List<int>{};
        while (rdr.Read())
        {
            int id = rdr.GetInt32(0);
            string itemDescription = rdr.GetString(1);
            DateTime dueDate = rdr.GetDateTime(2);
            Item foundItem = new Item(itemDescription, dueDate, id);
            allItems.Add(foundItem);
        }
        conn.Close();
        if (conn != null)
        {
        conn.Dispose();
        }

        return allItems;
    }
  }
}

