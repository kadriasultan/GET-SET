using System;

public class Person
{
    private string _name;
    private int _age;
    private string _email;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Age
    {
        get { return _age; }
        set
        {
            if (value > 0) // Validatie: leeftijd moet groter zijn dan 0
            {
                _age = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Leeftijd moet groter zijn dan 0.");
            }
        }
    }

    public string Email
    {
        get { return _email; }
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Contains("@"))
            {
                _email = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Ongeldig emailadres.");
            }
        }
    }

    public Person(string name, int age, string email)
    {
        Name = name;
        Age = age;
        Email = email;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Naam: {Name}");
        Console.WriteLine($"Leeftijd: {Age}");
        Console.WriteLine($"Email: {Email}");
    }
}

class Program
{
    static void Main(string[] args) // Correcte definitie van de Main methode
    {
        try
        {
            // Maak een nieuw object van de Person klasse
            Person person = new Person("Jan Jansen", 30, "jan.jansen@example.com");

            // Print de informatie van de persoon
            person.PrintInfo();

            // Probeer een ongeldige leeftijd in te stellen
            person.Age = -5; // Dit zal een uitzondering veroorzaken
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Fout: {ex.Message}");
        }
    }
}