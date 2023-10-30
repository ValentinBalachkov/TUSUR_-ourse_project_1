using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Data/Config", order = 1)]
public class Config : ScriptableObject
{
    [SerializeField] private int _maxWordLenght;
    
}
