using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UFO", menuName = "SO/UFO_SO", order = 51)]
public class UFO_SO : ScriptableObject
{
    [SerializeField] private float _switchDirTime = 5;
    [SerializeField] private int _getPoints = 200;

    public float SwitchDirTime => _switchDirTime;
    public int GetPoints => _getPoints;
}
