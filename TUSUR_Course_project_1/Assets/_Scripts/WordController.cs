using System.Collections.Generic;
using System.Linq;

public class WordController
{
    private Config _config;
    public WordController(Config config)
    {
        _config = config;
    }
    
    public List<string> GetCorrectWords(string wordsArray)
    {
        List<string> correctWords = new List<string>();
        List<string> words = new(wordsArray.Split(' ').ToList());
        string firstWord = words[0];
        List<string> otherWords = new(words.GetRange(1, words.Count - 1));

        foreach (var word in otherWords)
        {
            correctWords.Add(word);
            foreach (var currentChar in word)
            {
                if (!firstWord.Contains(currentChar))
                {
                    correctWords.Remove(word);
                    break;
                }
            }
        }

        return correctWords;
    }
}
