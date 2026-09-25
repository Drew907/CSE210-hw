using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        int gnum = 0;
        Console.Write("What is the magic number? ");
        string mNumber =Console.ReadLine();
        int mnum = int.Parse(mNumber);
        
      
        
        while(gnum != mnum)
        {
            
        
            Console.Write("What is your guess?  ");
            string gNumber =Console.ReadLine();
        


            gnum = int.Parse(gNumber);
                if (gnum > mnum)
                    {
                      Console.WriteLine("Lower");
                    }
                else if (gnum < mnum)
                    {
                    Console.WriteLine("Higher");
                    }
                else
                    {
                    Console.WriteLine("You got it!");
                    }
        }
        
    }
}    
