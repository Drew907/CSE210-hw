using System;

namespace Fraction;
class Program
{
    static void Main(string[] args)
    {

        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());


        Fraction f2 = new Fraction(5,1);
        
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3,4);
        
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1,3);
        
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());


        Random random = new Random();
        Fraction f5 = new Fraction();
        for  (int n = 0; n < 20; n++)
        {
            //get random value between 1-11 for top and bottom
            int topValue = random.Next(1, 11);
            int bottomValue = random.Next(1, 11);

            f5.setTop(topValue);
            f5.SetBottom(bottomValue);
            
            Console.Write($"Fraction {n + 1}: ");
            Console.Write($"string: {f5.GetFractionString()}");
            Console.WriteLine($" Number: {f5.GetDecimalValue()}");
        }
    }
}