using System.Collections;
using UnityEngine;

public class EventController : MonoBehaviour
{

	[SerializeField] private ObjectGenerator_SO ObjGen_SO;
	private int asteroidCount;
	private Vector3 _asteroidDirection;

	private float _UFOSpawnDelay;
	private float _heigh = Screen.height / 200;
	private float _width = Screen.width / 200;
	private float e = 0.7f;
	private float x, y;
	private float _timer;

	public GameObject[] AsteroidList => ObjGen_SO.AsteroidList;

	System.Random random = new System.Random();


	private void Start()
	{
		_UFOSpawnDelay = Random.Range(ObjGen_SO.MinTimeSpawnUFO, ObjGen_SO.MaxTimeSpawnUFO);
		asteroidCount = ObjGen_SO.AmountOfAsteroids;
	}

	private void Update()
	{
		UFOSpawner();
	}

	public void Reset()
    {
		ClearLevel();
		asteroidCount = ObjGen_SO.AmountOfAsteroids;
		StopAllCoroutines();
		StartCoroutine("SpawnIt");
	}


	public void RespawnAndNextLevel(int asteroidsLast)
	{
		if (asteroidsLast == 0)
		{
			asteroidCount++;

			StartCoroutine("SpawnIt");
		}
	}

	public void ClearLevel()
	{
		if (FindObjectsOfType<Asteroid>().Length > 0)
			foreach (var A in FindObjectsOfType<Asteroid>())
				Destroy(A.gameObject);

		if (FindObjectsOfType<UFO>().Length > 0)
			foreach (var u in FindObjectsOfType<UFO>())
				Destroy(u.gameObject);

		if (FindObjectsOfType<Bullet>().Length > 0)
			foreach (var b in FindObjectsOfType<Bullet>())
				Destroy(b.gameObject);

		if (FindObjectsOfType<UFOBullet>().Length > 0)
			foreach (var ub in FindObjectsOfType<UFOBullet>())
				Destroy(ub.gameObject);
	}

	private void UFOSpawner()
	{
		_timer += Time.deltaTime;

		if (_timer > _UFOSpawnDelay && FindObjectsOfType<UFO>().Length == 0)
		{
			int n = random.Next(0, 2);
			int binRand = random.Next(0, 2);
			double doubleRand = random.NextDouble();

			float rand = Mathf.Pow(-1, binRand) * (float)doubleRand;

			x = Mathf.Pow(-1, n) * (_width - e);
			y = rand * (_heigh - e);
			Vector2 spawnPos = new Vector2(x, y);

			_timer = 0;
			_UFOSpawnDelay = Random.Range(ObjGen_SO.MinTimeSpawnUFO, ObjGen_SO.MaxTimeSpawnUFO);
			Instantiate(ObjGen_SO.UFOPrefab, spawnPos, Quaternion.identity);

		}
	}

	private Vector2 SpawnCoords()
	{
		System.Random random = new System.Random();

		int n = random.Next(0, 2);
		int side = random.Next(0, 2);
		int signRand = random.Next(0, 2);

		double d_rand = random.NextDouble();

		float rand = Mathf.Pow(-1, signRand) * (float)d_rand;

		if (side == 0)
		{
			x = Mathf.Pow(-1, n) * (_width - e);
			y = rand * (_heigh - e);
		}
		else
		{
			x = rand * (_width - e);
			y = Mathf.Pow(-1, n) * (_heigh - e);
		}
		Vector2 spawnPos = new Vector2(x, y);

		return spawnPos;
	}


	IEnumerator SpawnIt()
	{
		yield return new WaitForSeconds(2f);

		int count = asteroidCount;

		if (FindObjectsOfType<UFO>().Length > 0)
		{
			foreach (var ufo in FindObjectsOfType<UFO>())
			{
				Destroy(ufo.gameObject);
			}
		}

		while (count > 0)
		{
			count--;

			_asteroidDirection = new Vector3(Random.Range(-0.9f, 0.9f), Random.Range(-0.9f, 0.9f));

			GameObject obj = Instantiate(ObjGen_SO.AsteroidList[ObjGen_SO.AsteroidList.Length - 1], SpawnCoords(), Quaternion.identity);
			obj.transform.localRotation = Quaternion.FromToRotation(transform.up, _asteroidDirection);

			obj.GetComponent<Rigidbody2D>().velocity = obj.transform.up * ObjGen_SO.AsteroidSpeed * Time.fixedDeltaTime;

			yield return new WaitForSeconds(0.05f);
		}
	}
}
