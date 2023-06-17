
using System;

Console.WriteLine("Hello!");
string userInput;
var toDoList = new List<string>();
do
{
    Console.WriteLine("\n");
    Console.WriteLine("Whats do you want to do?");
    Console.WriteLine("[S]ee all TODOs.");
    Console.WriteLine("[A]dd a TODO.");
    Console.WriteLine("[R]emove a TODO.");
    Console.WriteLine("[E]xit.");
    Console.Write("Enter : ");
    userInput = Console.ReadLine();
    userInput = userInput.ToUpper();

    if (userInput == "S")
    {
        SeeAllToDo();
    }
    else if (userInput == "A")
    {
        AddToDos();
    }
    else if (userInput == "R")
    {
        RemoveToDo(toDoList);
    }
    else if (userInput == "E")
    {
        Console.WriteLine(userInput);
    }
    else
    {
        Console.WriteLine("Invalid Choice!");
    }

} while (userInput != "E");

Console.ReadLine();
#region "SEE ALL TODOs"
void SeeAllToDo()
{
    if (toDoList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
    }
    else
    {
        for (int i = 0; i < toDoList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {toDoList[i]}");
        }
    }
}
#endregion
#region "ADD TODOs"
void AddToDos()
{
    while (true)
    {
        Console.WriteLine("Enter the TODO description: ");

        string inputToDo = Console.ReadLine();

        if (toDoList.Contains(inputToDo))
        {
            Console.WriteLine("The description must be unique. \n");
        }
        else if (string.IsNullOrWhiteSpace(inputToDo))
        {
            Console.WriteLine("The description cannot be empty.\n");
        }
        else
        {
            toDoList.Add(inputToDo);
            Console.WriteLine("TODO successfully added : " + inputToDo);
            return;
        }
    };
}
#endregion
#region "REMOVE ALL TODOs"
void RemoveToDo(List<string> list)
{
    
    SeeAllToDo();
    Console.WriteLine("Select the index of the TODO you want to remove: ");
    var toDoIndex = Console.ReadLine();
    bool tryParsing = int.TryParse(toDoIndex, out int toDoIndexNumber);
    if (!tryParsing)
    {
        Console.WriteLine("The given index is not valid.");
        return;
    }
    if (toDoIndexNumber <= 0)
    {
        Console.WriteLine("The given index is not valid.");
        return;
    }
    else if (string.IsNullOrWhiteSpace(toDoIndex.ToString()))
    {
        Console.WriteLine("Selected index cannot be empty.");
    }
    var removedToDo = list.ElementAt(toDoIndexNumber - 1);
    list.RemoveAt(toDoIndexNumber - 1);
    Console.WriteLine("TODO removed : " + removedToDo);
    return;
}
#endregion

