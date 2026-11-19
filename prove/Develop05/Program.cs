using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace Goal;


class Program
{
        static void Main(string[] args)
    {
        List<Goal> Goals = new List<Goal>();
        bool running = true;
        while (running == true)
        {
            AddPoints(Goals);
            Console.WriteLine("Menu Options:\r\n  1. Create New Goal\r\n  2. List Goals\r\n  3. Save Goals\r\n  4. Load Goals\r\n  5. Record Event\r\n  6. Quit\r\nSelect a choice from the menu:");
            string choice = Console.ReadLine();

   
        switch (choice)
        {
            case "1":
                NewGoal(Goals);
                break;

            case "2":
                DisplayGoals(Goals);
                break;

            case "3":
              Save(Goals);
            
                break;
            
            case "4":
                Read(Goals);
                break;

            case "5":
                Complete(Goals);
                break;

            case "6":
                running = false;
                break;


            default:
                Console.WriteLine("Invalid choice.");
                return;
        }
        }
    }
static void NewGoal(List<Goal> Goals)
{
    string date = DateTime.Now.ToString("MM/dd/yyyy");
    Console.WriteLine("The types of Goals are:\r\n  1. Simple Goal\r\n  2. Eternal Goal\r\n  3. Checklist Goal\r\nSelect a choice from the menu:");
    string choice = Console.ReadLine();
    
   
        switch (choice)
        {
            case "1":
            Console.WriteLine("What is the name of your goal?");
            string response1 = Console.ReadLine();
            Console.WriteLine("What is a short description of it?");
            string response2 = Console.ReadLine();
            Console.WriteLine("What is the amount of points associated with this goal?");
            string response3 = Console.ReadLine();
            int points = int.Parse(response3);
                Goals.Add(new SimpleGoal(response1,response2,points,false,date));
                break;

            case "2":
            Console.WriteLine("What is the name of your goal?");
            response1 = Console.ReadLine();
            Console.WriteLine("What is a short description of it?");
            response2 = Console.ReadLine();
            Console.WriteLine("What is the amount of points associated with this goal?");
            response3 = Console.ReadLine();
            points = int.Parse(response3);
                Goals.Add(new EternalGoal(response1,response2,points,0,date));
                break;

            case "3":
            Console.WriteLine("What is the name of your goal?");
            response1 = Console.ReadLine();
            Console.WriteLine("What is a short description of it?");
            response2 = Console.ReadLine();
            Console.WriteLine("What is the amount of points associated with this goal?");
            response3 = Console.ReadLine();
            Console.WriteLine("How many times does this goal need to be accomplished for a bonus?");
            string response4 = Console.ReadLine();
            Console.WriteLine("What is the bonus for accomplishing it that many times?");
            string response5 = Console.ReadLine();
            points = int.Parse(response3);
            int times = int.Parse(response4);
            int bonusPoints = int.Parse(response5);
           
            Goals.Add(new ChecklistGoal(response1,response2,points,times,bonusPoints,false,0,date));

                break;
            
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }
   
}
static void DisplayGoals(List<Goal> Goals)
    {
        int counter = 1;
        foreach (Goal goal in Goals)
        {
            Console.Write($"{counter}.");
            goal.Display();

            counter ++;
        }

    }
static void Complete(List<Goal> Goals)


    {
    Console.WriteLine("The goals are:");
    DisplayGoals(Goals);
    Console.WriteLine("Which goal did you accomplish?");
    string response = Console.ReadLine();
    int choice = int.Parse(response);
    choice -=1;
    Goal SelectedGoal = Goals[choice];
    SelectedGoal.Complete();

    }

static void AddPoints(List<Goal> Goals)
    {
        int PointsAdded = 0;
        foreach (Goal goal in Goals)
        {      
            bool completed = goal.GetCompleted();
            if (goal is SimpleGoal)
            {
            if (completed == true)
            {
            int points = goal.GetPoints();
            PointsAdded += points;
            }
            }

            if (goal is EternalGoal)
            {
                EternalGoal eternal = (EternalGoal)goal;
                int times = eternal.GetCompletedTimes();
                int points = eternal.GetPoints();
                PointsAdded += (times*points);
            }
            if (goal is ChecklistGoal)
            {
                ChecklistGoal checklist = (ChecklistGoal)goal;
                int times = checklist.GetCompleteNumber();
                int Completedtimes = checklist.GetCompletedTimes();
                int points = checklist.GetPoints();
                int bonus = checklist.GetBonusPoints();
                PointsAdded += Completedtimes * points;

                if (times == Completedtimes)
                {
                   

                    PointsAdded += bonus;
                }
            }
        }
        Console.WriteLine($"You have {PointsAdded} points.");
    }

static void Save(List<Goal> Goals)

    {
        Console.WriteLine("What is the filename for the goal file? ");
        string Filename = Console.ReadLine();

        using (StreamWriter OutputFile = new StreamWriter(Filename))
        {
        foreach (Goal goal in Goals)
            {
                string savestring = goal.GetSaveString();
                OutputFile.WriteLine(savestring);
            }   
        }
    }


static void Read(List<Goal> Goals)
    {
        Console.WriteLine("What is the filename for goal file?");
        string Filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(Filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(':');

            string goaltype = parts[0];
            string attributes = parts[1];

            string[] data = attributes.Split(',');

            switch (goaltype)
            {
                case "SimpleGoal":
                    Goals.Add(new SimpleGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2]),
                        bool.Parse(data[3]),
                        data[4]
                        
                    ));
                    break;

                case "EternalGoal":
                    Goals.Add(new EternalGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2]),
                        int.Parse(data[3]),
                        data[4]
                        
                    ));
                    break;

                case "ChecklistGoal":
                    Goals.Add(new ChecklistGoal(
                       data[0],
                       data[1],
                       int.Parse(data[2]),
                       int.Parse(data[4]),                       
                       int.Parse(data[5]),
                       bool.Parse(data[3]),
                       int.Parse(data[6]),
                       data[7]
                       
                    
                    ));
                    break;
            }
        }
    }
    
}




