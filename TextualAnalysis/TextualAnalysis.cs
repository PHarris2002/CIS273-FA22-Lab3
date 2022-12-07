using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextualAnalysis
{
    public class TextualAnalysis
    {
        public static string stopWordFilePath = "../../../Data/stop-words.txt";

        public TextualAnalysis()
        {
        }

        //returns the words as keys and returns int count as value
        public static Dictionary<string, int> ComputeWordFrequencies(string s, bool ignoreStopWords = false)
        {
            var wordCounts = new Dictionary<string, int>();
            // s = "all the faith he had had had had no effect."

            // remove punctuation
            var cleanString = Regex.Replace(s,@"[^\w\s]", "");

            // split the string into words(filtering out the empty strings)
            var words = cleanString.ToLower()
                                    .Split()
                                    .Where(s => s!="");

            string[] stopWords = GetStopWordsFromFile(stopWordFilePath);

            // create a hash set out of the given string (use string utilities as an example)
            HashSet<string> hashSet = new HashSet<string>();

            foreach (var word in words)
            {
                if (hashSet.Contains(word) == false)
                {
                    hashSet.Add(word);
                }
            }

            // if new, start with count of one
            foreach (var word in words)
            {
                //increment the word count if it's already in the dictionary
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word] = wordCounts[word] + 1;
                    continue;
                }

                //otherwise, add word if new with count of one
                // if not ignoring stop words and word is a stop word
                // skip the stop word, else add it
                else
                {
                    if (stopWords.Contains(word) && ignoreStopWords == true)
                    {
                        if (wordCounts.ContainsKey(word) == false)
                        {
                            wordCounts.Add(word, 0);
                        }

                        else
                        {
                            continue;
                        }
                    }

                        
                }
            }

            return wordCounts;
        }

        public static Dictionary<string, int> ComputeWordFrequenciesFromFile(string path, bool ignoreStopWords = false)
        {
            // read in the file
            string text = System.IO.File.ReadAllText(path);

            // call the previous method
            var result = ComputeWordFrequencies(text);

            // return the result of the other method

            return result;
        }

        private static string[] GetStopWordsFromFile(string path)
        {
            var rawLines = System.IO.File.ReadAllLines(path);
            var lines = new List<string>();

            foreach (var line in rawLines)
            {
                // ignore blank lines
                if (line.Trim() != "")
                {
                    lines.Add(line.Trim().ToLower());
                }
            }

            return lines.ToArray();
        }

    }
}
