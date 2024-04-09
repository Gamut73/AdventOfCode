using System;
using System.IO;
using System.Collections.Generic;

class Day1Trebuchet {
    static void Main() {
       int sum = 0;
       string inputFilePath;

       Console.WriteLine("Enter the path of the input file: ");
        inputFilePath = Console.ReadLine();

        string[] lines;
        try
       {
           lines = File.ReadAllLines(inputFilePath);
       }
       catch (IOException e)
       {
           Console.WriteLine($"Error reading file: {e.Message}");
           return;
       }

       foreach (string line in lines)
       {
           string lineWithoutNumWords = ReplaceNumberWordsWithDigits(line);
           sum += getCalibrationValue(lineWithoutNumWords);
       }

         Console.WriteLine($"The sum of the calibrations is: {sum}");

    }

    private static int getCalibrationValue(string calibration)
    {
        char? leftDigit = null;
        char? rightDigit = null;

        for (int i = 0; i < calibration.Length; i++)
        {
            if (char.IsDigit(calibration[i]))
            {
                if (leftDigit == null)
                {
                    leftDigit = calibration[i];
                }
                rightDigit = calibration[i];
            }
        }

        if (leftDigit == null || rightDigit == null)
        {
            return 0;
        }

        string concatenated = $"{leftDigit}{rightDigit}";
        return int.Parse(concatenated);
    }

    private static string ReplaceNumberWordsWithDigits(string input)
    {
        Dictionary<string, string> numberWordsToDigits = new Dictionary<string, string>
        {
            { "one", "o1e" },
            { "two", "t2o" },
            { "three", "t3e" },
            { "four", "f4r" },
            { "five", "f5e" },
            { "six", "s6x" },
            { "seven", "s7n" },
            { "eight", "e8t" },
            { "nine", "n9e" }
        };

        foreach (KeyValuePair<string, string> entry in numberWordsToDigits)
        {
            input = input.Replace(entry.Key, entry.Value);
        }

        return input;
    }
}