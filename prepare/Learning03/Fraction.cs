using System;
namespace Fraction;
public class Fraction
{
    private int _top;
    private int _bottom;




    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int num)
    {
        _top = num;
        _bottom = 1;

    }

    public Fraction(int topNum, int bottomNum)
    {
        _top = topNum;
        _bottom = bottomNum;

    }
    //sets top or bottom, bottom can't be 0
    public void SetBottom(int bottomNum)
    {
        if (bottomNum !=0)
        {
            _bottom = bottomNum;
        }
        else
        {
            _bottom =1;
        }

    }

    public void setTop(int topNum)
    {
        _top = topNum;
    }


    //returns top or bottom value 
    public int getBottom()
    {
        return _bottom;
    }
    public int getTop()
    {
        return _top;
    }

    public string GetFractionString()
    {
        string strNum = $"{_top}/{_bottom}";
        return strNum;
    }

    public double GetDecimalValue()
    {
        double value = (double)_top/(double)_bottom;
        return value;

    }
}