using System;
namespace Goal;

public class ChecklistGoal : Goal
{
    
    private int _times;
    int _CompletedTimes;
    private int _bonusPoints;

    public ChecklistGoal( string title, string description, int points,int times, int bonusPoints, bool complete,int completedTimes, string DateCreated)
    : base(title,description,points,DateCreated)
    {
        _times = times;
        _bonusPoints = bonusPoints;
        _CompletedTimes = completedTimes;
        _Completed = complete;

    }
    public override void Display()
    {
        if (_times == _CompletedTimes)
        {
        Console.WriteLine($"[X] {_title} ({_description})-- Currently completed {_CompletedTimes}/{_times}      Date Created:{_DateCreated}");
        }
        else
        {
        Console.WriteLine($"[ ] {_title} ({_description})-- Currently completed {_CompletedTimes}/{_times}      Date Created:{_DateCreated}"); 
        }
    }

    public override void Complete()
    {
        if (_CompletedTimes < _times)
        {
        _CompletedTimes ++;
        }
        if (_times == _CompletedTimes)
        {
            _Completed = true;
        }
    }



    public override string GetSaveString()
    {
        return ($"ChecklistGoal:{_title},{_description},{_points},{_Completed},{_times},{_bonusPoints},{_CompletedTimes},{_DateCreated}");
    }
    
    public int GetBonusPoints()
    {
        return _bonusPoints;
    }
    public int GetCompletedTimes()
    {
        return _CompletedTimes;
    }
    public int GetCompleteNumber()
    {
        return _times;
    }

}