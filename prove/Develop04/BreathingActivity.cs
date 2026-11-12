using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
namespace BaseActivity;
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