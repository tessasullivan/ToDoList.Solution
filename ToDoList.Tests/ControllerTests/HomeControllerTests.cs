using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Controllers;
using ToDoList.Models;

namespace ToDoList.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            HomeController controller = new HomeController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_ItemList()
        {
            // HomeController controller = new HomeController();
            // ViewResult indexView = controller.Index() as ViewResult;
            ViewResult indexView = new HomeController().Index() as ViewResult;
            var result = indexView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<item>));
        }

        [TestMethod]
        public void Create_ReturnsCorrectActionType_RedirectToActionResult()
        {
            ItemsController controller = new ItemsController();
            IActionResult view = controller.Create("Walk the dog");
            Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Create_RedirectsToCorrectAction_Index()
        {
            ItemsController controller = new ItemsController();
            RedirectToActionResult actionResult = controller.Create("Walk the dog") as RedirectToActionResult;
            string result = actionResult.ActionName;
            Assert.AreEqual(result, "Index");
        }
    }
}