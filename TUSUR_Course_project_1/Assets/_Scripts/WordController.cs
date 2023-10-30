using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordController
{
    private Config _config;
    private const string ACCESS_CHAR = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    public WordController(Config config)
    {
        _config = config;
    }
    
    public List<string> GetCorrectWords(string wordsArray)
    {
        List<string> words = new(wordsArray.Split(' ').ToList());

        List<string> correctWords = new List<string>();
        
        var error = IsSuccessWords(words);


        if (error != "")
        {
            correctWords.Add(error);
            return correctWords;
        }

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

    private string IsSuccessWords(List<string> words)
    {
        if (words.Count < _config.MinWordsCount)
        {
            DebugLogger.SendMessage("Words count less than permissible value", Color.red);
            return "Количество слов меньше допустимого значения";
        }

        foreach (var word in words)
        {
            if (word.Length > _config.MaxWordLenght)
            {
                DebugLogger.SendMessage("Word biggest then max word lenght", Color.red);
                return $"Слово не должно быть длиннее {_config.MaxWordLenght} символов";
            }

            foreach (var currentChar in word)
            {
                if (!ACCESS_CHAR.Contains(currentChar))
                {
                    DebugLogger.SendMessage($"Incorrect symbol {currentChar}", Color.red);
                    return $"Нераспознанный символ {currentChar}";
                }
            }
            
        }

        return "";
    }
}
