using System;
using System.Linq;

class Sportsman
{
    private string _name;

    public string Name
    {
        get { return _name; }
        private set { _name = value; }
    }

    public Sportsman(string name_)
    {
        Name = name_;
    }

    public virtual void Race()
    {
    }
}

class Skier : Sportsman
{
    private int _time;

    public int Time
    {
        get { return _time; }
        private set { _time = value; }
    }

    public Skier(string name_, int time) : base(name_)
    {
        Time = time;
    }

    public override void Race()
    {
        Console.WriteLine($"{Name} {Time}");
    }
}

class Femskier : Skier
{
    public Femskier(string name_, int time) : base(name_, time)
    {
    }

    public override void Race()
    {
        Console.WriteLine($" {Name} {Time}");
    }
}

class Program
{
    static void Main()
    {
        Skier[] femaleGroup1 = new Skier[]
        {
            new Femskier("Maria", 300),
            new Femskier("Anna", 320),
            new Femskier("Olga", 310),
            new Femskier("Lena", 346),
            new Femskier("Olga", 145)
        };

        Skier[] femaleGroup2 = new Skier[]
        {
            new Femskier("Elena", 280),
            new Femskier("Irina", 290),
            new Femskier("Natalia", 270),
            new Femskier("Anna", 150),
            new Femskier("Olga", 500)
        };

        Skier[] maleGroup1 = new Skier[]
        {
            new Skier("Alex", 250),
            new Skier("Peter", 260),
            new Skier("Michael", 240),
            new Skier("Ivan", 230),
            new Skier("Rob", 210)
        };

        Skier[] maleGroup2 = new Skier[]
        {
            new Skier("John", 220),
            new Skier("Robert", 230),
            new Skier("William", 210),
            new Skier("Lesha", 250),
            new Skier("Boris", 260)
        };

        femaleGroup1 = BubbleSort(femaleGroup1);
        femaleGroup2 = BubbleSort(femaleGroup2);
        maleGroup1 = BubbleSort(maleGroup1);
        maleGroup2 = BubbleSort(maleGroup2);

        Console.WriteLine("Results for female skiers group 1:");
        DisplayResults(femaleGroup1);

        Console.WriteLine("\nResults for female skiers group 2:");
        DisplayResults(femaleGroup2);

        Console.WriteLine("\nResults for male skiers group 1:");
        DisplayResults(maleGroup1);

        Console.WriteLine("\nResults for male skiers group 2:");
        DisplayResults(maleGroup2);

        Console.WriteLine("\nOverall results for female skiers:");
        DisplayResults(femaleGroup1.Concat(femaleGroup2).ToArray());

        Console.WriteLine("\nOverall results for male skiers:");
        DisplayResults(maleGroup1.Concat(maleGroup2).ToArray());

        Skier[] allSkiers = femaleGroup1.Concat(femaleGroup2).Concat(maleGroup1).Concat(maleGroup2).ToArray();

        allSkiers = BubbleSort(allSkiers);

        Console.WriteLine("Results for all skiers:");
        DisplayResults(allSkiers);
    }

    static Skier[] BubbleSort(Skier[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j].Time > array[j + 1].Time)
                {
                    Skier temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        return array;
    }

    static void DisplayResults(Skier[] skiers)
    {
        foreach (var skier in skiers)
        {
            skier.Race();
        }
    }
}