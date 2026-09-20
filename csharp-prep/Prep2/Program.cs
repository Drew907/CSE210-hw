using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
      Console.WriteLine("Enter you grade in percentage:");
      string percs =Console.ReadLine();
      int perc = int.Parse(percs);

    if (perc >= 90)
        {
            Console.WriteLine("A");
        }
    else if (perc >= 80)
        {
            Console.WriteLine("B");
        }
    else if (perc >= 70)
        {
            Console.WriteLine("C");
        }
    else if (perc >= 60)
        {
            Console.WriteLine("D");
        }
    else {Console.WriteLine("F");
    }



    }
}