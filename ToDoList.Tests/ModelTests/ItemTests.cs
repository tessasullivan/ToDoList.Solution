using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
  {
    public void Dispose()
    {
      Item.ClearAll();
    }
    public ItemTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=to_do_list_test;convert zero datetime=True";
    }

    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      string item = "test";
      DateTime dueDate = new DateTime(2019, 05, 06);
      Item newItem = new Item(item, dueDate);
      Assert.AreEqual(typeof(Item), newItem.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string description = "Walk the dog.";
      DateTime dueDate = new DateTime(2019, 05, 06);
      Item newItem = new Item(description, dueDate);
      string result = newItem.GetDescription();
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      string description = "Walk the dog.";
      DateTime dueDate = new DateTime(2019, 05, 06);
      Item newItem = new Item(description, dueDate);

      string updatedDescription = "Do the dishes";
      newItem.SetDescription(updatedDescription);
      string result = newItem.GetDescription();

      Assert.AreEqual(updatedDescription, result);
    }
    [TestMethod]
    public void GetDueDate_ReturnsDueDate_String()
    {
      string description = "Walk the dog.";
      DateTime dueDate = new DateTime(2019, 05, 06);
      Item newItem = new Item(description, dueDate);
      DateTime result = newItem.GetDueDate();
      Assert.AreEqual(result, dueDate);
    }
    [TestMethod]
    public void SetDueDate_SetsDueDate_String()
    {
      string description = "Walk the dog.";
      DateTime dueDate = new DateTime(2019, 03, 15);
      Item newItem = new Item(description, dueDate);
      DateTime newDueDate = new DateTime(2019, 05, 06);
      newItem.SetDueDate(newDueDate);
      DateTime result = newItem.GetDueDate();
      Assert.AreEqual(result, newDueDate);
    }
    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
    {
      List<Item> newList = new List<Item> { };
      List<Item> result = Item.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      DateTime dueDate = new DateTime(2019, 03, 15);

      Item firstItem = new Item("Mow the lawn", dueDate);
      Item secondItem = new Item("Mow the lawn", dueDate);
      Assert.AreEqual(firstItem, secondItem);
    }
    [TestMethod]
    public void Save_SavesToDatabase_ItemList()
    {
      DateTime dueDate = new DateTime(2019, 03, 15);
      Item testItem = new Item("Mow the lawn", dueDate);

      testItem.Save();
      List<Item> result = Item.GetAll();
      List<Item> testList = new List<Item>{testItem};

      CollectionAssert.AreEqual(testList, result);
    }
    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      //Arrange
      DateTime dueDate = new DateTime(2019, 03, 15);
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01, dueDate);
      Item newItem2 = new Item(description02, dueDate);
      newItem1.Save();
      newItem2.Save();

      List<Item> newList = new List<Item> { newItem1, newItem2 };

      //Act
      List<Item> result = Item.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
    // [TestMethod]
    // public void Sort_ReturnsSortedList_ItemList()
    // {
    //   DateTime dueDate1 = new DateTime(2019, 03, 15);
    //   DateTime dueDate2 = new DateTime(2019, 01, 15);
    //   string description01 = "Walk the dog";
    //   string description02 = "Wash the dishes";
    //   Item newItem1 = new Item(description01, dueDate1);
    //   Item newItem2 = new Item(description02, dueDate2);
    //   List<Item> newList = new List<Item> { newItem1, newItem2 };
    //   List<Item> expectedResult = new List<Item> { newItem2, newItem1 };
    //   List<Item> result = Item.Sort();
    //   System.Console.WriteLine(newList);
    //   CollectionAssert.AreEqual(expectedResult, result);
    // }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      DateTime dueDate = new DateTime(2019, 03, 15);
      Item testItem = new Item("Mow the lawn", dueDate);
      testItem.Save();
      Item savedItem = Item.GetAll()[0];
      int result = savedItem.GetId();
      int testId = testItem.GetId();
      Assert.AreEqual(testId, result);
    }

    // [TestMethod]
    // public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //     //Arrange
    //     DateTime dueDate = new DateTime(2019, 03, 15);
    //     string description = "Walk the dog.";
    //     Item newItem = new Item(description, dueDate);

    //     //Act
    //     int result = newItem.GetId();

    //     //Assert
    //     Assert.AreEqual(1, result);
    // }
    [TestMethod]
    public void Find_ReturnsCorrectItemFromDatabase_Item()
    {
      //Arrange
      DateTime dueDate = new DateTime(2019, 03, 15);
      Item testItem = new Item("Mow the Lawn", dueDate);
      testItem.Save();

      //Act
      Item foundItem = Item.Find(testItem.GetId());

      //Assert
      Assert.AreEqual(testItem, foundItem);
    }
    [TestMethod]
    public void EditDescription_UpdatesItemInDatabase_String()
    {
      string description = "Walk the dog.";
      string secondDescription = "Mow the lawn";
      DateTime dueDate = new DateTime(2019, 03, 15);
      Item testItem = new Item(description, dueDate);
      testItem.Save();
      testItem.EditDescription(secondDescription);
      string actualResult = Item.Find(testItem.GetId()).GetDescription();
      // System.Console.WriteLine("actualresult " +actualResult);
      Assert.AreEqual(secondDescription, actualResult);
    }
  }
}