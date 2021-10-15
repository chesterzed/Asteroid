using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))] 
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;

    private float _directionX = 0;
    private float _directionY = 0;


    private void FixedUpdate()
    {
        _directionX = Input.GetAxis("Horizontal");
        _directionY = Input.GetAxis("Vertical");

        _playerMover.MoveDirection(_directionX, _directionY);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Asteroid>())
            _player.ApplyDamage();
    }
}
