using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VolumeLevel", menuName = "ScriptableObjects/VolumeLevel", order = 2)]
public class VolumeLevel : ScriptableObject
{
    public float volume = 0.01f;
}
