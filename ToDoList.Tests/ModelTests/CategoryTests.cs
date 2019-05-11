using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTest : IDisposable
  {
    public CategoryTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=to_do_list_with_dueDate_test;convert zero datetime=True;";
    }
    public void Dispose()
    {
      Category.ClearAll();
    }
    [TestMethod]
    public void CategoryConstructor_CreatesInstanceOfCategory_Category()
    {
        string name = "Test Category";
        Category newCategory = new Category(name);
        Assert.AreEqual(typeof(Category), newCategory.GetType());
    }
    [TestMethod]
    public void GetName_ReturnsName_String()
    {
        string name = "Test Category";
        Category newCategory = new Category(name);
        string actualResult = newCategory.GetName();
        Assert.AreEqual(name, actualResult);
    }
    // [TestMethod]
    // public void GetId_ReturnsCategoryId_Int()
    // {
    //     string name = "Test Category";
    //     Category newCategory = new Category(name);
    //     int actualResult = newCategory.GetId();
    //     Assert.AreEqual(1, actualResult);
    // }
    [TestMethod]
    public void GetAll_CategoriesEmptyAtFirst_List()
    {
      int result = Category.GetAll().Count;
      Assert.AreEqual(0, result);
    }
    [TestMethod]
    public void GetAll_ReturnsAllCategoryObjects_CategoryList()
    {
        string name01 = "Work";
        string name02 = "School";
        Category newCategory1 = new Category(name01);
        newCategory1.Save();
        Category newCategory2 = new Category(name02);
        newCategory2.Save();
        List<Category> newList = new List<Category> { newCategory1, newCategory2 };

        List<Category> actualResult = Category.GetAll();
        CollectionAssert.AreEqual(newList, actualResult);
    }
    [TestMethod]
    public void Find_ReturnsCategoryInDB_Category()
    {
        string name01 = "Work";
        Category testCategory = new Category(name01);
        testCategory.Save();
        Category actualResult = Category.Find(testCategory.GetId());
        Assert.AreEqual(testCategory, actualResult);
    }
    // [TestMethod]
    // public void GetItems_ReturnsEmptyItemList_ItemList()
    // {
    //     string name = "Work";
    //     Category newCategory = new Category(name);
    //     List<Item> newList = new List<Item> { };
    //     List<Item> actualResult = newCategory.GetItems();
    //     CollectionAssert.AreEqual(newList, actualResult);
    // }
    // [TestMethod]
    // public void AddItem_AssociatesItemWithCategory_ItemList()
    // {
    //     //Create an item and add to item list
    //     string description = "Walk the dog";
    //     string categoryName = "Home";
    //     DateTime dueDate = new DateTime(2019, 03, 15);
    //     Item newItem = new Item(description, dueDate, 1);
    //     List<Item> newList = new List<Item>{ newItem };
    //     Category newCategory = new Category(categoryName);
    //     newCategory.AddItem(newItem);

    //     List<Item> actualResult = newCategory.GetItems();
    //     CollectionAssert.AreEqual(newList, actualResult);
    // }
    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Category()
    {
      Category firstCategory = new Category("Household chores");
      Category secondCategory = new Category("Household chores");
      Assert.AreEqual(firstCategory, secondCategory);

    }
    [TestMethod]
    public void Save_SavesCategoryToDatabase_CategoryList()
    {
      Category testCategory = new Category("Household chores");
      testCategory.Save();
      List<Category> result = Category.GetAll();
      List<Category> testList = new List<Category>{testCategory};
      CollectionAssert.AreEqual(testList, result);
    }
    [TestMethod]
    public void Save_DatabaseAssignsIdToCategory_Id()
    {
      Category testCategory = new Category("Household chores");
      testCategory.Save();
      Category savedCategory = Category.GetAll()[0];
      int result = savedCategory.GetId();
      int testId = testCategory.GetId();
      Assert.AreEqual(testId, result);

    }
  }
}
