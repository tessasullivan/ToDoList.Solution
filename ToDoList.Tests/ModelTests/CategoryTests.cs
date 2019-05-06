using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTest : IDisposable
  {
    public void Dispose()
    {
      Category.ClearAll();
    }
    // [TestMethod]
    // public void CategoryConstructor_CreatesInstanceOfCategory_Category()
    // {
    //     string name = "Test Category";
    //     Category newCategory = new Category(name);
    //     Assert.AreEqual(typeof(Category), newCategory.GetType());
    // }
    // [TestMethod]
    // public void GetName_ReturnsName_String()
    // {
    //     string name = "Test Category";
    //     Category newCategory = new Category(name);
    //     string actualResult = newCategory.GetName();
    //     Assert.AreEqual(name, actualResult);
    // }
    // [TestMethod]
    // public void GetId_ReturnsCategoryId_Int()
    // {
    //     string name = "Test Category";
    //     Category newCategory = new Category(name);
    //     int actualResult = newCategory.GetId();
    //     Assert.AreEqual(1, actualResult);
    // }
    // [TestMethod]
    // public void GetAll_ReturnsAllCategoryObjects_CategoryList()
    // {
    //     string name01 = "Work";
    //     string name02 = "School";
    //     Category newCategory1 = new Category(name01);
    //     Category newCategory2 = new Category(name02);
    //     List<Category> newList = new List<Category> { newCategory1, newCategory2 };

    //     List<Category> actualResult = Category.GetAll();
    //     CollectionAssert.AreEqual(newList, actualResult);
    // }
    // [TestMethod]
    // public void Find_ReturnsCorrectCategory_Category()
    // {
    //     string name01 = "Work";
    //     string name02 = "School";
    //     Category newCategory1 = new Category(name01);
    //     Category newCategory2 = new Category(name02);
    //     Category actualResult = Category.Find(2);
    //     Assert.AreEqual(newCategory2, actualResult);
    // }
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
    //     Item newItem = new Item(description);
    //     List<Item> newList = new List<Item>{ newItem };

    //     // Create a category and add item to it
    //     // create a list from GetItems
    //     string name = "Home";
    //     Category newCategory = new Category(name);
    //     newCategory.AddItem(newItem);
    //     List<Item> actualResult = newCategory.GetItems();
    //     CollectionAssert.AreEqual(newList, actualResult);
    // }
  }
}
