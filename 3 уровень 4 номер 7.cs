using System;
using System.Linq;

class Sportsman
{
    public string name { get; set; }

    public Sportsman(string name_)
    {
        name = name_;
    }

    public virtual void Race()
    {
    }
}

class Skier : Sportsman
{
    public int time { get; set; }

    public Skier(string name_, int time_) : base(name_)
    {
        time = time_;
    }

    public override void Race()
    {
        Console.WriteLine($"{name} {time} ");
    }
}

class Femskier : Skier
{
    public Femskier(string name_, int time_) : base(name_, time_)
    {
    }

    public override void Race()
    {
        Console.WriteLine($" {name} {time}");
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
            new Femskier("Olga", 310)
        };

        Skier[] femaleGroup2 = new Skier[]
        {
            new Femskier("Elena", 280),
            new Femskier("Irina", 290),
            new Femskier("Natalia", 270)
        };

        Skier[] maleGroup1 = new Skier[]
        {
            new Skier("Alex", 250),
            new Skier("Peter", 260),
            new Skier("Michael", 240)
        };

        Skier[] maleGroup2 = new Skier[]
        {
            new Skier("John", 220),
            new Skier("Robert", 230),
            new Skier("William", 210)
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
    }

    static Skier[] BubbleSort(Skier[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j].time > array[j + 1].time)
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
