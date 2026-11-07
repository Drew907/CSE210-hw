using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

class BaseActivity
{
    protected string _name;
    protected int _duration;
    protected string _description;

    public BaseActivity(string name, int duration)
    {
        _name = name;
        _duration = duration;    
    }
    
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine(_description);
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
    }
    public void PauseWithCountdown(int seconds)
    {
         for (int i = seconds; i > 0; i--)
    {
        Console.Write(i);
        Thread.Sleep(1000);
        Console.Write("\b \b");
    }
    }
    public void DisplayAnimation()
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
      
        for (int i =10; i > 0; i--)
        {
        foreach (string s in animationStrings)
        {
            Console.Write(s);
            Thread.Sleep(100);
            Console.Write("\b \b");
        }
        }
    }
}

class BreathingActivity : BaseActivity
{
     public BreathingActivity()
        : base("Breathing Activity", 0)
    {
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        Console.Clear();
        DisplayBreathInOut(_duration);
        DisplayEndingMessage();
        DisplayAnimation();
        Console.Clear();
    }
    protected void DisplayBreathInOut(int duration)
        {
        DateTime startTime = DateTime.Now;

         while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.WriteLine("Breathe in...");
            PauseWithCountdown(4);
            if ((DateTime.Now - startTime).TotalSeconds >= duration)
            {
                break;
            }
            Console.WriteLine("Breathe out...");
            PauseWithCountdown(4);
        }
        }

}

class ReflectionActivity : BaseActivity
{

    private List<string> _Prompts = new List<string>();
    private List<string> _Questions = new List<string>();

    public ReflectionActivity()
        : base("Reflection Activity", 0)
    {
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _Prompts.Add("Think of a time when you stood up for someone else.");
        _Prompts.Add("Think of a time when you did something really difficult.");
        _Prompts.Add("Think of a time when you helped someone in need.");
        _Prompts.Add("Think of a time when you did something truly selfless.");
        _Questions.Add("Why was this experience meaningful to you?");
        _Questions.Add("Have you ever done anything like this before?");
        _Questions.Add("How did you get started?");
        _Questions.Add("How did you feel when it was complete?");
        _Questions.Add("What made this time different than other times when you were not as successful?");
        _Questions.Add("What is your favorite thing about this experience?");
        _Questions.Add("What could you learn from this experience that applies to other situations?");
        _Questions.Add("What did you learn about yourself through this experience?");
        _Questions.Add("How can you keep this experience in mind in the future?");
    }
    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        DisplayAnimation();
        Console.WriteLine("Consider the following prompt:\n");
        DisplayPrompt();
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        string temp = Console.ReadLine();
        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.\nYou may begin in:");
        PauseWithCountdown(5);
        Console.Clear();
        DisplayQuestions(_duration);
        DisplayEndingMessage();
        DisplayAnimation();
        Console.Clear();    
    }
    protected void DisplayQuestions(int duration)
    {
        DateTime startTime = DateTime.Now;

         while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            DisplayQuestion();
            PauseWithCountdown(9);

            if ((DateTime.Now - startTime).TotalSeconds >= duration)
            {
                break;
            }   
        }      
    }
    protected void DisplayPrompt()
    {
        Random random = new Random();

        int index = random.Next(_Prompts.Count);

        Console.WriteLine(_Prompts[index]);
    }

    protected void DisplayQuestion()
    {
       Random random = new Random();

        int index = random.Next(_Questions.Count);

        Console.WriteLine(_Questions[index]); 
    }
}

class ListingActivity : BaseActivity
{
    private List<string> _Prompts = new List<string>();
    private List<string> _Response = new List<string>();

    public ListingActivity()
            : base("Listing Activity", 0)
        {
            _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
            _Prompts.Add("Who are people that you appreciate?");
            _Prompts.Add("What are personal strengths of yours?");
            _Prompts.Add("Who are people that you have helped this week?");
            _Prompts.Add("When have you felt the Holy Ghost this month?");
            _Prompts.Add("Who are some of your personal heroes?");
        }
    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        DisplayAnimation();
        Console.WriteLine("List as many responses you can to the following prompt:");
        DisplayPrompt();
        Console.WriteLine("You may begin in:");
        PauseWithCountdown(5);
        EntryList(_duration);    
        Console.WriteLine($"You have entered {_Response.Count} responses");
        DisplayEndingMessage();
        DisplayAnimation();
        Console.Clear();       
    }

    protected void EntryList(int duration)
        {        
        DateTime startTime = DateTime.Now;

         while ((DateTime.Now - startTime).TotalSeconds < duration)
        {        
            string response = Console.ReadLine();
            _Response.Add(response);

            if ((DateTime.Now - startTime).TotalSeconds >= duration)
            {
                break;
            }   
        }
        }
    protected void DisplayPrompt()
    {
        Random random = new Random();
        int index = random.Next(_Prompts.Count);
        Console.WriteLine(_Prompts[index]); 
   }   
}

class Program
{
        static void Main(string[] args)
    {
        bool running = true;
        while (running == true)
        {
            Console.WriteLine("Menu Options:\r\n  1. Start breathing activity\r\n  2. Start reflection activity\r\n  3. Start listing activity\r\n  4. Quit");
            string choice = Console.ReadLine();

   
        switch (choice)
        {
            case "1":
                
                BreathingActivity A1 = new BreathingActivity();
                A1.Run(); 
                break;

            case "2":
                ReflectionActivity A2 = new ReflectionActivity();
                A2.Run();
                break;

            case "3":
                ListingActivity A3 = new ListingActivity();
                A3.Run();
                break;
            
            case "4":
                running = false;
                break;


            default:
                Console.WriteLine("Invalid choice.");
                return;
        }
        }
    }
}