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
    public ActionResult Create(string description, DateTime dueDate)
    {
      Item newItem = new Item(description, dueDate);
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
    // [HttpGet("/categories/{categoryId}/items/{itemId}/edit")]
    // public ActionResult Edit(int categoryId, int itemId)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category category = Category.Find(categoryId);
    //   Item item = Item.Find(itemId);
    //   model.Add("category", category);
    //   model.Add("item", item);
    //   return View(model);
    // }
    // [HttpPost("/categories/{categoryId}/items/{itemId}")]
    // public ActionResult Update(int categoryId, int itemId, string newDescription)
    // {
    //   Item item = Item.Find(itemId);
    //   item.EditDescription(newDescription);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category category = Category.Find(categoryId);
    //   model.Add("category", category);
    //   model.Add("item", item);
    //   return View("Show", model);
    // }

    // [HttpPost("/categories/{categoryId}/items/{itemId}/delete")]
    // public ActionResult Delete(int itemId)
    // {
    //   Item item = Item.Find(itemId);
    //   item.Delete();
    //   return RedirectToAction("Index", "Categories");
    //   // return View("Show");
    // }

    // [HttpGet("/categories/{categoryId}/items/{itemId}/delete")]
    // public ActionResult Delete(int categoryId, int itemId)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category category = Category.Find(categoryId);
    //   Item item = Item.Find(itemId);
    //   model.Add("category", category);
    //   model.Add("item", item);
    //   return View(model);
    // }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
        Item.ClearAll();
        return View();
    }
  }
}