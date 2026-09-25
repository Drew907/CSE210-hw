using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int fnum = PromptUserNumber();
        int square = SquareNumber(fnum);

        int birthyear;
        PromtUserBirthYear(out birthyear);

        DisplayResult(name, square, birthyear);









        static void DisplayWelcome()
        {
            Console.WriteLine("Welcom to the program!");
        }
        static string PromptUserName()
        {      
            Console.Write("Please enter your name:");
            string name =Console.ReadLine();
            return name;
        }
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number:");
            string sNum =Console.ReadLine();
            int fnum = int.Parse(sNum);
            return fnum;
        }
        static void PromtUserBirthYear(out int birthyear)
        {
            Console.WriteLine("Please enter the year you were born:");
            string num =Console.ReadLine();
            birthyear = int.Parse(num);

        }

        static int SquareNumber(int fnum)
        {
            int square = fnum * fnum;
            return square;
        }

        static void DisplayResult(string name, int square, int birthyear )
        {
            Console.WriteLine($"{name}, the square of your number is {square}.");
            Console.WriteLine($"{name}, you will turn {2025 - birthyear} years old this year.");


        }
       
        

    }
}