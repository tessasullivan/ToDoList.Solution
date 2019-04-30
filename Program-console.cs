using System;
using System.Collections.Generic;

namespace ToDoList.Models
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the To Do List.");
            userPrompt();         
        }
        public static void userPrompt()
            {
                Console.WriteLine("Would you like to add an item to your list or view your list? (Add/View/Quit)");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "add")
                {
                    System.Console.WriteLine("Enter the item to add");
                    string newItemStr = Console.ReadLine();
                    Item newItem = new Item(newItemStr);
                    System.Console.WriteLine("Your item: " + newItem.GetDescription() +  " has been added to your list.");
                    userPrompt();
                }
                else if (userInput == "view")
                {
                    List<Item> myList = Item.GetAll();
                    foreach(Item item in myList)
                    {
                        System.Console.WriteLine(item.GetDescription());
                    }
                    userPrompt();
                }
                else if (userInput == "quit")
                {
                    System.Console.WriteLine("Thanks for using To Do List (TM)");
                }
                else 
                {
                    System.Console.WriteLine("Command not recognized, please choose Add or View");
                    userPrompt();
                }
            }
    }
}