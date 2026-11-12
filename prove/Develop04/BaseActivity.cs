using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
namespace BaseActivity;
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