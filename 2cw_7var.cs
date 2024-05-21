using System.Collections.Generic;
using System.IO;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

abstract class Task
{
    protected string text = "No text here yet";
    protected string check = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public Task(string text)
    {

        this.text = text;
    }
}

class Task1 : Task
{
    private int answer = 0;
    [JsonConstructor]
    public Task1(string text) : base(text) { }
    private void Solution()
    {
        int[] letters = new int[check.Length];
        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < check.Length; j++)
            {
                if (text[i].ToString().ToUpper() == check[j].ToString())
                {
                    letters[j]++;
                }
            }
        }
        for (int i = 0; i < letters.Length; ++i)
        {
            if (letters[i] > 0)
            {
                ++answer;
            }
        }
    }

    public override string ToString()
    {
        Solution();
        return answer.ToString();
    }
}
class Task2 : Task
{
    private List<string> answer;
    [JsonConstructor]
    public Task2(string text) : base(text)
    {
        this.answer = new List<string>();
    }
    private void Solution()
    {
        string[] words = text.Split(" ,-!.:;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach (string w in words)
        {
            int[] letters = new int[check.Length];
            for (int i = 0; i < w.Length; i++)
            {
                for (int j = 0; j < check.Length; j++)
                {
                    if (w[i].ToString().ToUpper() == check[j].ToString())
                    {
                        letters[j]++;
                    }
                }
            }
            bool flag = true;
            for (int i = 0; i < letters.Length; ++i)
            {
                if (letters[i] > 1)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                answer.Add(w);
            }
        }
    }
    public override string ToString()
    {
        Solution();
        return string.Join(",", answer.ToArray());
    }
}

class JsonIO
{
    public static void Write<T>(T obj, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, obj);
        }
    }
    public static T Read<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
        return default(T);
    }
}
class Program
{
    static void Main()
    {
        string text = "На улице хороший день, чтобы пойти гулять"; 
        Task[] tasks = {
            new Task1(text),
            new Task2(text)
        };
        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);

        string path = @"C:\Users\m2312317\Desktop"; 
        string folderName = "Solution";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "task_1.json";
        string fileName2 = "task_2.json";

        fileName1 = Path.Combine(path, fileName1);
        fileName2 = Path.Combine(path, fileName2);


        if (!File.Exists(fileName1))
        {
            JsonIO.Write<Task1>(tasks[0] as Task1, fileName1);
        }
        if (!File.Exists(fileName2))
        {
            JsonIO.Write<Task2>((Task2)tasks[1], fileName2);
        }
        else
        {
            var t1 = JsonIO.Read<Task1>(fileName1);
            var t2 = JsonIO.Read<Task2>(fileName2);
            Console.WriteLine(t1);
            Console.WriteLine(t2);
        }


    }
}