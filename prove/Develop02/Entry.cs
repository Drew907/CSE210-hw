using System;
namespace Entry;

public class Entry
{
    // atributes
    private string _date;
    private string _selectedPrompt;
    private string _response;

    public Entry(string _date, string _selectedPrompt, string _response)
{
    this._date = _date;
    this._selectedPrompt = _selectedPrompt;
    this._response = _response;
}

    // Methods
        public void Display(string name, int number)
        {
            Console.WriteLine($"{name} - Entry #{number}");
            Console.WriteLine($"Date: {_date}");
            Console.WriteLine($"Prompt: {_selectedPrompt}");
            Console.WriteLine($"Response: {_response}");
            Console.WriteLine();
        }

     // returns atributes that are private 
     // Return the date
    public string GetDate()
    {
        return _date;
    }

    // Return the prompt
    public string GetPrompt()
    {
        return _selectedPrompt;
    }

    // Return the response
    public string GetResponse()
    {
        return _response;
    }





}
