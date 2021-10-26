using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class UFOMover : MonoBehaviour
{
	[SerializeField] private Movers_SO _movers;

	private Vector3 _direction;

	private Vector3 _playerPos;

	public void SwitchDirection(int rand, float side)
	{
		_direction = Quaternion.AngleAxis(45f * rand, Vector3.forward) * transform.right;
		if (side == 0)
			GetComponent<Rigidbody2D>().velocity = Math.Sign(GetComponent<Rigidbody2D>().velocity.x) * (transform.right + _direction) * _movers.Speed * Time.deltaTime;
		else
			GetComponent<Rigidbody2D>().velocity = side * (transform.right + _direction) * _movers.Speed * Time.deltaTime;
	}

	public void Shoot()
	{
		_playerPos = (FindObjectOfType<Player>().transform.position - transform.position).normalized;

		Instantiate(_movers.BulletsPrefab[1], transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(_playerPos * _movers.BulletSpeed, ForceMode2D.Force);
	}
}
