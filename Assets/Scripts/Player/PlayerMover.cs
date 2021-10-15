using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        //rb.GetComponent<Rigidbody2D>();
    }

    public void MoveDirection(float directionX, float directionY)
    {
        rb.velocity = new Vector2(directionX * _speed * Time.fixedDeltaTime, directionY * _speed * Time.fixedDeltaTime);
    }
    
}
