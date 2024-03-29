using System;
using System.Linq;

abstract class Answer
{
    private string _name;
    private int _votes;

    public string Name
    {
        get { return _name; }
        private set { _name = value; }
    }

    public int Votes
    {
        get { return _votes; }
        private set { _votes = value; }
    }

    public Answer(string name, int votes)
    {
        Name = name;
        Votes = votes;
    }

    public abstract void Print();
}

class Person : Answer
{
    public Person(string name, int votes) : base(name, votes)
    {
    }

    public override void Print()
    {
        double percentage = ((double)Votes / 680) * 100;
        Console.WriteLine($"Person of the year: {Name} - {percentage:0.00}%");
    }
}

class Discovery : Answer
{
    public Discovery(string name, int votes) : base(name, votes)
    {
    }

    public override void Print()
    {
        double percentage = ((double)Votes / 752) * 100;
        Console.WriteLine($"Discovery of the year: {Name} - {percentage:0.00}%");
    }

}

class Program
{

    static void Main()
    {
        Answer[] results = new Answer[]
        {
            new Person("Ivan", 150),
            new Person("Katya", 120),
            new Person("Lera", 135),
            new Person("Igor", 150),
            new Person("Lena", 125),
            new Discovery("Internet", 140),
            new Discovery("Television", 120),
            new Discovery("Motor car", 157),
            new Discovery("Electricity", 190),
            new Discovery("Photography", 145)
        };

        Console.WriteLine("Answers for Person of the year:");
        PersonResults(results);

        Console.WriteLine("\nAnswers for Discovery of the year:");
        DiscoveryResults(results);
    }

    static void PersonResults(Answer[] answers)
    {
        foreach (var answer in answers.OfType<Person>())
        {
            answer.Print();
        }
    }

    static void DiscoveryResults(Answer[] answers)
    {
        foreach (var answer in answers.OfType<Discovery>())
        {
            answer.Print();
        }
    }
}
