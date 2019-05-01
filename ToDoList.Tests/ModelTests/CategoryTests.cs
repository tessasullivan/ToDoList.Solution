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
    [TestMethod]
    public void GetId_ReturnsCategoryId_Int()
    {
        string name = "Test Category";
        Category newCategory = new Category(name);
        int actualResult = newCategory.GetId();
        Assert.AreEqual(1, actualResult);
    }
    [TestMethod]
    public void GetAll_ReturnsAllCategoryObjects_CategoryList()
    {
        string name01 = "Work";
        string name02 = "School";
        Category newCategory1 = new Category(name01);
        Category newCategory2 = new Category(name02);
        List<Category> newList = new List<Category> { newCategory1, newCategory2 };

        List<Category> actualResult = Category.GetAll();
        CollectionAssert.AreEqual(newList, actualResult);
    }
    [TestMethod]
    public void Find_ReturnsCorrectCategory_Category()
    {
        string name01 = "Work";
        string name02 = "School";
        Category newCategory1 = new Category(name01);
        Category newCategory2 = new Category(name02);
        Category actualResult = Category.Find(2);
        Assert.AreEqual(newCategory2, actualResult);
    }
  }
}
