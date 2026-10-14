
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Entry;

class Program
{
    static List<Entry> entries = new List<Entry>();

    static Random random = new Random();

    // list of prompts
    static List<string> prompts = new List<string>
    {
        "What was the best part of your day?",
        "What did you learn today?",
        "What are you grateful for?",
        "What is a goal you want to accomplish?",
        "What is something you want to improve?"
    };

    // main program
    static void Main(string[] args)
    {

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== My journal ===");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Save Entry");
            Console.WriteLine("3. Display Entries");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddEntry();
                    break;
                
                case "2":
                    SaveJournal(entries);
                    break;

                case "3":
                    DisplayEntry();
                    break;

                case "4":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
    // creates new entry object
    static void AddEntry()
    {
        string _selectedPrompt =
            prompts[random.Next(prompts.Count)];

        Console.WriteLine(_selectedPrompt);
        Console.Write("Response: ");

        string _response = Console.ReadLine() ?? "";
        string _date = DateTime.Now.ToString("MM/dd/yyyy");

        Entry newEntry = new Entry(_date, _selectedPrompt, _response);

        entries.Add(newEntry);

        

        Console.WriteLine("Entry added successfully!");
    }
    // displays whats in the "Entries.txt" file
    static void DisplayEntry()
    {
        Console.WriteLine("Reading list from file...");
        List<Entry> Entries = new List<Entry>();
        string filename = "Entries.txt";
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~");
            

            

            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];
            Console.WriteLine($"Date: {date}");
            Console.WriteLine($"Prompt: {prompt}");
            Console.WriteLine($"Response: {response}");
            Console.WriteLine("");
            Console.WriteLine("");
        
        }
    }

    // saves journal objects into "Entries.txt" 
    static void SaveJournal(List<Entry> entries)
{
    {
        string filename = "Entries.txt";
        using (StreamWriter outputfile = new StreamWriter(filename,true))
        {
            foreach (Entry e in entries)
            {
                outputfile.WriteLine($"{e.GetDate()}~{e.GetPrompt()}~{e.GetResponse()}");
            }
           Console.WriteLine("Save succesfull");
        }

    }
}


    
}

