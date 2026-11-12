using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
namespace BaseActivity;
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