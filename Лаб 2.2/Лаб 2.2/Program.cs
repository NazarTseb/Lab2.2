using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>()
        {
            {"A", 10},
            {"B", 20},
            {"C", 5},
            {"D", 30},
            {"E", 5}
        };

        List<int> result = FindMinMaxValues(dictionary);

        if (result.Count == 0)
        {
            Console.WriteLine("Словник порожній.");
        }
        else
        {
            Console.WriteLine("Максимальне та мінімальне значення словника:");
            foreach (int value in result)
            {
                Console.WriteLine(value);
            }
            
            SaveToJson(dictionary, "dictionary.json");
            Console.WriteLine("Результати збережено у файлі dictionary.json");
        }
    }

    static List<int> FindMinMaxValues(Dictionary<string, int> dictionary)
    {
        List<int> result = new List<int>();

        if (dictionary.Count == 0)
        {
            return result; 
        }

        int maxValue = dictionary.Values.Max();
        int minValue = dictionary.Values.Min();

        if (dictionary.Values.Count(val => val == maxValue) == 1)
        {
            result.Add(maxValue);
        }

        if (dictionary.Values.Count(val => val == minValue) == 1)
        {
            result.Add(minValue);
        }

        return result;
    }

    static void SaveToJson(Dictionary<string, int> dictionary, string filePath)
    {
        string json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
        System.IO.File.WriteAllText(filePath, json);
    }
}
