using System;

class Program
{
    public static string Longest_Common_Prefix(string[] strings)
    {
        if (strings == null || strings.Length == 0)
        {
            return "";                                          // If array is empty, return an empty string
        }

                                                                // Initialize the prefix with the first string
        string prefix = strings[0];

                                                                // Iterate over each string starting from the second one
        for (int i = 1; i < strings.Length; i++)
        {
                                                                // Compare each character in the current prefix with the current string
            int j = 0;
            while (j < prefix.Length && j < strings[i].Length && prefix[j] == strings[i][j])
            {
                j++;                                            // Move to the next character
            }

            prefix = prefix.Substring(0, j);                    // Update prefix if the common part found 
        }

        return prefix;                                          // Return the longest common prefix found
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter elements of the string array separated by spaces:");
        string input = Console.ReadLine(); // Read user input

                                                                // Split the input string by spaces and convert it into a string array
        string[] strs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string longestPrefix = Longest_Common_Prefix(strs);     // Find longest common prefix

        Console.WriteLine($"Longest Common Prefix: {longestPrefix}");
    }
}
