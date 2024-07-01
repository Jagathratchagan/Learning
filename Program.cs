using System;

public class SentenceReverser
{   

    public static void Main()
    {

        Console.WriteLine("Please enter your input sting : ");

        // Get input
        string input = Console.ReadLine();

        // Reverse logic
        string output = ReverseWords(input);

        Console.WriteLine("Original: " + input);
        Console.WriteLine("Reversed: " + output);
    }

    public static string ReverseWords(string sentence)
    {        
        string[] words = sentence.Split(' ');
        
        Array.Reverse(words);
        
        string reversedSentence = string.Join(" ", words);

        return reversedSentence;
    }

}

