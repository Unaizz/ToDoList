
using System;

Console.WriteLine("Hello!");
string userInput;
var toDoList = new List<string>();

Console.WriteLine("\n");
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
        SeeAllToDo(toDoList);
    }
    else if (userInput == "A")
    {
        AddToDos(toDoList);
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

} while (userInput.ToUpper() != "E");

Console.ReadLine();
#region "SEE ALL TODOs"
void SeeAllToDo(List<string> list)
{
    if (list.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
    }
    foreach (string item in list)
    {
        list.IndexOf(item);
        Console.WriteLine($"{list.IndexOf(item) + 1}. {item}");
    }
}
#endregion
#region "ADD TODOs"
List<string> AddToDos(List<string> list)
{
    while (true)
    {
        Console.WriteLine("Enter the TODO description: ");

        string inputToDo = Console.ReadLine();

        if (list.Contains(inputToDo))
        {
            Console.WriteLine("The description must be unique. \n");
        }
        else if (string.IsNullOrWhiteSpace(inputToDo))
        {
            Console.WriteLine("The description cannot be empty.\n");
        }
        else
        {
            list.Add(inputToDo);
            Console.WriteLine("TODO successfully added : " + inputToDo);
            return list;
        }
    };
    return list;
}
#endregion
#region "REMOVE ALL TODOs"
List<string> RemoveToDo(List<string> list)
{
    if (list.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
        return list;
    }

    SeeAllToDo(list);
    Console.WriteLine("\nSelect the index of the TODO you want to remove: ");
    var toDoIndex = Console.ReadLine();
    bool tryParsing = int.TryParse(toDoIndex, out int toDoIndexNumber);
    if (!tryParsing)
    {
        Console.WriteLine("The given index is not valid.");
        return list;
    }
    if (toDoIndexNumber <= 0)
    {
        Console.WriteLine("The given index is not valid.");
        return list;
    }
    else if (string.IsNullOrWhiteSpace(toDoIndex.ToString()))
    {
        Console.WriteLine("Selected index cannot be empty.");
    }
    var removedToDo = list.ElementAt(toDoIndexNumber - 1);
    list.RemoveAt(toDoIndexNumber - 1);
    Console.WriteLine("TODO removed : " + removedToDo);
    return list;
}
#endregion

