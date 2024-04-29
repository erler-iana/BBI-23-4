using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

abstract class Task
{
    protected string text = "";
    protected string checker = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public string Text
    {
        get => text;
        protected set => text = value;
    }

    protected virtual void Solution() { }
    public Task(string text)
    {
        this.text = text;
    }
}

class Task1 : Task
{
    private string answer;
    public string Answer
    {
        get => answer;
        protected set => answer = value;
    }
    public Task1(string text) : base(text)
    {
        answer = "";
    }
    protected override void Solution()
    {
        int tmpLength = 0;
        int last = 50 - (text.Length % 50);
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == ' ' && tmpLength == 0)
            {
                continue;
            }
            if (checker.Contains(text.ToUpper()[i]))
            {
                int keepLength = tmpLength;
                string word = "";
                tmpLength++;
                word += text[i];
                while (i + 1 < text.Length && checker.Contains(text.ToUpper()[i + 1]))
                {
                    word += text[i + 1];
                    ++i;
                    ++tmpLength;
                }
                if (tmpLength > 50)
                {
                    string[] l_ = answer.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < 50 - keepLength; j++)
                        answer = answer.Insert(answer.Length - l_[l_.Length - 1].Length - 1, " ");
                    answer += '\n';
                    ++last;
                    tmpLength = word.Length;
                }
                answer += word;
                continue;
            }
            answer += text[i];
            tmpLength++;
            if (tmpLength >= 50)
            {
                ++last;
                answer += "\n";
                tmpLength = 0;
            }

        }
        string[] l = answer.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int j = 0; j <= (answer.Length - last) % 50; j++)
            answer = answer.Insert(answer.Length - l[l.Length - 1].Length - 1, " ");
    }

    public override string ToString()
    {
        Solution();
        return Convert.ToString(answer);
    }
}
class Task2 : Task
{
    private string answer;
    private string changeText;
    Dictionary<char, string> codes;
    int code = 100;
    public string Answer
    {
        get => answer;
    }
    public Dictionary<char, string> Codes
    {
        get => codes;
    }
    public Task2(string text) : base(text)
    {
        answer = "";
        codes = new Dictionary<char, string>();
        changeText = text.ToLower();
        Solution();
    }

    private bool ReplaceIteration()
    {
        Dictionary<string, int> counter = new Dictionary<string, int>();
        for (int i = 0; i < changeText.Length; i++)
        {
            if (i + 1 < changeText.Length && checker.Contains(changeText.ToUpper()[i]) && checker.Contains(changeText.ToUpper()[i + 1]))
            {
                string pair = Convert.ToString(changeText[i]) + changeText[i + 1];
                if (counter.ContainsKey(pair))
                {
                    counter[pair]++;
                }
                else
                {
                    counter[pair] = 1;
                }
                if (changeText[i] == changeText[i + 1] && i + 2 < changeText.Length && changeText[i + 1] == changeText[i + 2])
                    ++i;
            }
        }
        string changePair = "";
        int mx = 0;
        foreach (string pair in counter.Keys)
        {
            if (counter[pair] > mx)
            {
                mx = counter[pair];
                changePair = pair;
            }
        }
        string tmp = "";
        for (int i = 0; i < changeText.Length; i++)
        {
            if (i + 1 < changeText.Length && Convert.ToString(changeText[i]) + changeText[i + 1] == changePair)
            {
                ++i;
                continue;
            }
            tmp += changeText[i];
        }
        changeText = tmp;
        while (text.Contains((char)code) || codes.ContainsKey((char)code))
        {
            ++code;
        }
        codes[(char)code] = changePair;
        return true;
    }
    protected override void Solution()
    {
        for (int i = 0; i < 5; ++i)
        {
            ReplaceIteration();
        }
        answer = text;
        foreach (var i in codes)
        {
            answer = answer.Replace(i.Value, Convert.ToString(i.Key));
        }
    }
    public override string ToString()
    {
        return string.Join(Environment.NewLine, codes) + '\n' + answer + '\n';
    }
}
class Task3 : Task
{
    private string answer;
    Dictionary<char, string> dict;
    public string Answer
    {
        get => answer;
    }
    public Task3(string text, Dictionary<char, string> _dict) : base(text)
    {
        answer = "";
        dict = _dict;
    }

    protected override void Solution()
    {
        foreach (var i in text)
        {
            if (dict.ContainsKey(i))
            {
                answer += dict[i];
            }
            else
            {
                answer += i;
            }
        }
    }
    public override string ToString()
    {
        Solution();
        return answer;
    }
}
class Task4 : Task
{
    private string answer;
    public string code;
    public string uncode;
    private Dictionary<string, string> codes;
    private Dictionary<string, string> decodes;
    private List<string> codeText;
    public string Answer
    {
        get => answer;
    }

    public string Code
    {
        get => code;
    }
    public Task4(string text, Dictionary<string, string> _dict) : base(text)
    {
        answer = "";
        codes = _dict;
        code = text;
        codeText = new List<string>();
        decodes = new Dictionary<string, string>();
        foreach (var i in codes)
        {
            decodes[i.Value] = i.Key;
        }
    }

    protected override void Solution()
    {
        foreach (var i in codes)
        {
            text = text.Replace(i.Key, i.Value);
        }
        code = text;
        foreach (var i in decodes)
        {
            text = text.Replace(i.Key, i.Value);
        }
        answer = text;
    }
    public override string ToString()
    {
        Solution();
        return code + '\n' + answer;
    }
}
class Task5 : Task
{
    private Dictionary<char, double> answer;
    public Dictionary<char, double> Answer
    {
        get => answer;
    }
    public Task5(string text) : base(text)
    {
        answer = new Dictionary<char, double>();
    }

    protected override void Solution()
    {
        string[] wrd = text.Split(" ,-!.:;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
        foreach (string word in wrd)
        {
            char start = word.ToLower()[0];
            if (stat.ContainsKey(start))
                stat[start]++;
            else
                stat.Add(start, 1);
        }
        foreach (var tmp in stat)
        {
            answer.Add(tmp.Key, tmp.Value / (double)wrd.Length);

        }
    }
    public override string ToString()
    {
        Solution();
        return string.Join(Environment.NewLine, answer);
    }
}
class Task6 : Task
{
    private int answer;
    public int Answer
    {
        get => answer;
    }
    public Task6(string text) : base(text)
    {
        answer = 0;
    }

    protected override void Solution()
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] >= '0' && text[i] <= '9')
            {
                int num = 0;
                while (i < text.Length && text[i] >= '0' && text[i] <= '9')
                {
                    num *= 10;
                    num += text[i] - '0';
                    i++;
                }
                --i;
                answer += num;
            }
        }
    }
    public override string ToString()
    {
        Solution();
        return answer.ToString();
    }
}

class Program
{
    static void Main()
    {
        string text = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений. ";
        Dictionary<string, string> d = new Dictionary<string, string>();
        d["После"] = "#$@^";
        d["Анализ"] = "*@!&";
        d["показал"] = "!@#$%";
        d["что"] = "%^&*(";
        d["деятельность"] = "&*()!";
        Task[] tasks = {
            new Task1(text),
            new Task2(text),
            new Task3(new Task2(text).Answer, new Task2(text).Codes),
            new Task4(text, d),
            new Task5(text),
            new Task6(text)
        };
        Console.WriteLine(tasks[0] + "\n");
        Console.WriteLine(tasks[1] + "\n");
        Console.WriteLine(tasks[2] + "\n");
        Console.WriteLine(tasks[3] + "\n");
        Console.WriteLine(tasks[4] + "\n");
        Console.WriteLine(tasks[5] + "\n");
    }
}
