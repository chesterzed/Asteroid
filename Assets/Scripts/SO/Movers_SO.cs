using UnityEngine;

[CreateAssetMenu(fileName = "Movers", menuName = "SO/Movers_SO", order = 51)]
public class Movers_SO : ScriptableObject
{
	// Player Mover
	[SerializeField] private float _maxSpeed = 5;
	[SerializeField] private float _rotationKeyboardSpeed;
	[SerializeField] private float _rotationMouseSpeed;
	[SerializeField] private float _accelerationFactor;

	// UFO Mover
	[SerializeField] private float _UFOSpeed = 2;

	//Bullets
	[SerializeField] private GameObject[] _bulletPrefab;
	[SerializeField] private float _bulletSpeed;


	public float MaxSpeed => _maxSpeed;
	public float RotationKeyboardSpeed => _rotationKeyboardSpeed;
	public float RotationMouseSpeed => _rotationMouseSpeed;
	public float AccelerationFactor => _accelerationFactor;

	public float Speed => _UFOSpeed;

	public GameObject[] BulletsPrefab => _bulletPrefab;
	public float BulletSpeed => _bulletSpeed;
}
