using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _HP = 3;

    private int _score = 0;

    private void Score(int points)
    {
        _score += points;
    }

    private void Health()
    {

    }

    public void ApplyDamage()
    {
        _HP--;
    }
}
