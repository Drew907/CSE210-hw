using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        
        List<string> numbers = new List<string>();
        int uInt = 999;
        int pnum = 0;
        int sum = 0;
        int avg = 0;
        int Lnum = 0;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (uInt != 0)
        {
            Console.Write("Enter number:");
            string uInput =Console.ReadLine();
            uInt = int.Parse(uInput);
            numbers.Add(uInput);

        }
        foreach (string num in numbers)
        {
            Console.WriteLine(num);
            pnum = int.Parse(num);
            sum = sum + pnum;
            if (pnum> Lnum)
            {
                Lnum = pnum;
            }
            
        }
        int count = numbers.Count;
        avg = sum / count;
        Console.WriteLine($"The average is:  {avg}");
        Console.WriteLine($"The sum is:  {sum}");
        Console.WriteLine($"The largest number is:  {Lnum}");
        

    }
}