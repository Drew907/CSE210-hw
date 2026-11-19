using System;
using System.Runtime.CompilerServices;
namespace Goal;

public class EternalGoal : Goal
{
    int _CompletedTimes;

    public EternalGoal( string title, string description, int points,int completedTimes, string DateCreated)
    : base(title,description,points, DateCreated)
    {

        _CompletedTimes = completedTimes;
    }

    public override void Display()
    {
        Console.WriteLine($"[ ] {_title} ({_description})      Date Created:{_DateCreated}");       
    }
    public override string GetSaveString()
    {
        return ($"EternalGoal:{_title},{_description},{_points},{_CompletedTimes},{_DateCreated}");
    }
    public override void Complete()
    {
        _CompletedTimes ++;
        _Completed = true;
    }
    public int GetCompletedTimes()
    {
        return _CompletedTimes;
    }



}