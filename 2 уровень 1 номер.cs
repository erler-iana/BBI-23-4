using System;

namespace _1_уровень_3_номер
{
    class Person
    {
        public string name { get; set; }

        public Person(string name_)
        {
            name = name_;
        }
    }

    class Student : Person
    {
        public int nomer { get; set; }
        public double sr { get; set; }

        public Student(string name_, int nomer_, double firstExam, double secondExam, double thirdExam, double fourthExam) : base(name_)
        {
            nomer = nomer_;
            sr = Math.Round((firstExam + secondExam + thirdExam + fourthExam) / 4, 2);
        }

        public void Print()
        {
            Console.WriteLine($"{name},   {nomer},   {sr}");
        }
    }

    class Program
    {
        static void Main()
        {
            Student[] results = new Student[5];
            results[0] = new Student("Cherep", 34, 5, 2, 3, 5);
            results[1] = new Student("Chufireva", 1, 5, 5, 4, 4);
            results[2] = new Student("Perminova", 16, 2, 4, 4, 5);
            results[3] = new Student("Katina", 30, 4, 3, 3, 5);
            results[4] = new Student("Ivanov", 5, 5, 4, 3, 2);

            for (int i = 0; i < results.Length - 1; i++)
            {
                for (int j = 0; j < results.Length - 1 - i; j++)
                {
                    if (results[j].sr < results[j + 1].sr)
                    {
                        var temp = results[j];
                        results[j] = results[j + 1];
                        results[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("ФИО" + "   № студ. билета" + "   Средний балл");
            foreach (var result in results)
            {
                result.Print();
            }
        }
    }
}
