using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
namespace BaseActivity;
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