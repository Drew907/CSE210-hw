using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
namespace BaseActivity;










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