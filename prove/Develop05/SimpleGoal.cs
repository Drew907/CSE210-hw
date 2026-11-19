using System;
using System.Runtime.CompilerServices;
namespace Goal;



public class SimpleGoal : Goal
{



    public SimpleGoal( string title, string description, int points,bool complete,string DateCreated)
    : base(title,description,points,DateCreated)
    {
        _Completed = complete;
    }
    
    public override void Display()
    {
        if (_Completed == true)
        {
        Console.WriteLine($"[X] {_title} ({_description})      Date Created:{_DateCreated}");
        }
        else
        {
        Console.WriteLine($"[ ] {_title} ({_description})      Date Created:{_DateCreated}"); 
        }
    }
           
    public override string GetSaveString()
    {

        
        return ($"SimpleGoal:{_title},{_description},{_points},{_Completed},{_DateCreated}");
    }
    
    

}