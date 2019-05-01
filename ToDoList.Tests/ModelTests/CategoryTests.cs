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
      Item.ClearAll();
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

  }
}
