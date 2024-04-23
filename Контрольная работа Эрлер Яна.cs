using System;
using System.IO;
using System.Text.Json;

namespace CombinedTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            string userDirectory = FileManager.CreateUserDirectory("m231231@edu.misis.ru");
            string answerDirectory = FileManager.CreateSubDirectory(userDirectory, "Answer");

            JsonManager.ProcessJson(answerDirectory, "task_1.json", new { Name = "Task 1", Description = "Description for Task 1" });
            JsonManager.ProcessJson(answerDirectory, "task_2.json", new { Name = "Task 2", Description = "Description for Task 2" });

            StringProcessor.ProcessWords("Словом можно убить, словом можно и спасти.");
        }
    }

    static class FileManager // Task 3 (проверка файла)
    {
        public static string CreateUserDirectory(string directoryName)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), directoryName);
            EnsureDirectoryExists(path);
            return path;
        }

        public static string CreateSubDirectory(string basePath, string subDirectory)
        {
            string path = Path.Combine(basePath, subDirectory);
            EnsureDirectoryExists(path);
            return path;
        }

        private static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }

    static class JsonManager // Task 4 (JSON)
    {
        public static void ProcessJson(string directoryPath, string fileName, object data)
        {
            string filePath = Path.Combine(directoryPath, fileName);
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                Console.WriteLine($"Содержимое файла {Path.GetFileName(filePath)}: {jsonData}");
            }
            else
            {
                string jsonData = JsonSerializer.Serialize(data);
                File.WriteAllText(filePath, jsonData);
                Console.WriteLine($"Файл {Path.GetFileName(filePath)} создан и данные записаны.");
            }
        }
    }

    static class StringProcessor // Task 1 (JSON)
    {
        public static void ProcessWords(string input)
        {
            string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            int middleIndex = words.Length / 2;
            Console.WriteLine("Слово посередине фразы:");
            if (words.Length % 2 == 0)
                Console.WriteLine(words[middleIndex - 1]); // Если чётное количество, выводим слово перед серединой
            else
                Console.WriteLine(words[middleIndex]);     // Если нечётное количество, выводим среднее слово
        }
    }
}
