using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
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
