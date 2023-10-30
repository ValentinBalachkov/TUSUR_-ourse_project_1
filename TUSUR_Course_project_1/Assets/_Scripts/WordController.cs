using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordController
{
    private Config _config;
    public WordController(Config config)
    {
        _config = config;
    }
    
    public List<string> GetCorrectWords(string wordsArray)
    {
        List<string> words = new(wordsArray.Split(' ').ToList());

        foreach (var word in words)
        {
            if (word.Length > _config.MaxWordLenght)
            {
                DebugLogger.SendMessage("Word biggest then max word lenght", Color.red);
                return null;
            }
        }

        List<string> correctWords = new List<string>();
        string firstWord = words[0];
        List<string> otherWords = new(words.GetRange(1, words.Count - 1));

        foreach (var word in otherWords)
        {
            correctWords.Add(word);

            if (word.Length > firstWord.Length)
            {
                correctWords.Remove(word);
                continue;
            }
            
            foreach (var currentChar in word)
            {
                if (!firstWord.Contains(currentChar))
                {
                    correctWords.Remove(word);
                    break;
                }

                if(firstWord.Count(x => x == currentChar) <  word.Count(x => x == currentChar))
                {
                    correctWords.Remove(word);
                    break;
                }
            }
        }

        return correctWords;
    }
}
