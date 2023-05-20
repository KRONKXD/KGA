using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "ScriptableObjects/Difficulty", order = 1)]
public class Difficulty : ScriptableObject
{
    [SerializeField] private int _value;

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }
    
}
