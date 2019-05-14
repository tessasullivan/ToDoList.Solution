using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/items")]
    public ActionResult Index()
    {
      List<Item> allItems = Item.GetAll();
      return View(allItems);
    }
    [HttpGet("/items/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/items")]
    public ActionResult Create(string itemDescription, DateTime dueDate)
    {
      Item newItem = new Item(itemDescription, dueDate);
      newItem.Save();
      List<Item> allItems = Item.GetAll();
      return View("Index", allItems);
    }

    [HttpGet("/items/{id}")]
    public ActionResult Show(int id)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Item selectedItem = Item.Find(id);
        List<Category> itemCategories = selectedItem.GetCategories();
        List<Category> allCategories = Category.GetAll();
        model.Add("selectedItem", selectedItem);
        model.Add("itemCategories", itemCategories);
        model.Add("allCategories", allCategories);
        return View(model);
    }
    [HttpPost("/items/{itemId}/categories/new")]
    public ActionResult AddCategory(int itemId, int categoryId)
    {
      Item item = Item.Find(itemId);
      Category category = Category.Find(categoryId);
      item.AddCategory(category);
      return RedirectToAction("Show", new {id = itemId});
    }
    [HttpGet("/items/{itemId}/edit")]
    public ActionResult Edit(int itemId)
    {
      Item item = Item.Find(itemId);
      return View(item);
    } 
    [HttpPost("/items/{itemId}")]
    public ActionResult Update(int itemId, string newDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Item selectedItem = Item.Find(itemId);
      selectedItem.EditDescription(newDescription);
      List<Category> itemCategories = selectedItem.GetCategories();
      List<Category> allCategories = Category.GetAll();
      model.Add("selectedItem", selectedItem);
      model.Add("itemCategories", itemCategories);
      model.Add("allCategories", allCategories);
      return View("Show", model);
    }

    [HttpGet("/items/{itemId}/delete")]
    public ActionResult Delete(int itemId)
    {
      Item item = Item.Find(itemId);
      return View(item);
    }

    [HttpPost("/items/{itemId}/delete")]
    public ActionResult DeleteItem(int itemId)
    {
      Item item = Item.Find(itemId);
      item.Delete();
      List<Item> allItems = Item.GetAll();      
      return View("Index", allItems);
    }
    [HttpPost("/items/deleteAll")]
    public ActionResult DeleteAll()
    {
        Item.ClearAll();
        return View();
    }
  }
}