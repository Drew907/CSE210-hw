using System;
using System.ComponentModel.DataAnnotations;
namespace Goal;


public abstract class Goal
{
    protected string _title;
    protected string _description;
    protected int _points;

    protected bool _Completed;

    protected string _DateCreated;

    public Goal(string title, string description, int points, string DateCreated)
    {
        _title = title;
        _description = description;
        _points = points;
        _Completed = false;
        _DateCreated = DateCreated;
    }

    public abstract void Display();

    public abstract string GetSaveString();

    public int GetPoints()
    {
        return _points;
    }

    public virtual void Complete()
    {
        _Completed = true;
    }

    public bool GetCompleted()
    {
        return _Completed;
    }


}



