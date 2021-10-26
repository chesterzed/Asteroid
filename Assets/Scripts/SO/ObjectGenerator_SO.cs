using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectGenerator", menuName = "SO/ObjGen_SO", order = 51)]
public class ObjectGenerator_SO : ScriptableObject
{
	[SerializeField] private UFO _UFOPrefab;
	[SerializeField] private int _amountOfAsteroids;
	[SerializeField] private float _asteroidSpeed;
	[SerializeField] private float _minTimeSpawnUFO = 20f;
	[SerializeField] private float _maxTimeSpawnUFO = 40f;
	[SerializeField] private GameObject[] _asteroidList;

	public UFO UFOPrefab => _UFOPrefab;
	public float AsteroidSpeed => _asteroidSpeed;
	public float MinTimeSpawnUFO => _minTimeSpawnUFO;
	public float MaxTimeSpawnUFO => _maxTimeSpawnUFO;
	public int AmountOfAsteroids => _amountOfAsteroids;
	public GameObject[] AsteroidList => _asteroidList;
}
