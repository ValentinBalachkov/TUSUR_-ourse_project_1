using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Data/Config", order = 1)]
public class Config : ScriptableObject
{
    public int MaxWordLenght => _maxWordLenght;
    public int MinWordsCount => _minWordsCount;

    [SerializeField] private int _maxWordLenght;
    [SerializeField] private int _minWordsCount;
}
