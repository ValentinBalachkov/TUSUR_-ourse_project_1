using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Data/Config", order = 1)]
public class Config : ScriptableObject
{
    public int MaxWordLenght => _maxWordLenght;
    
    [SerializeField] private int _maxWordLenght;
}
