using UnityEngine;

public class Asteroid : MonoBehaviour
{ 
	[SerializeField] private int _size;

	[SerializeField] private float _asteroidSpeed = 2;
	[SerializeField] private int _getPoints = 100;

	private EventController _eventController;
	private UIController _UIController;
	private GameObject[] _asteroidList;

	private void OnEnable()
	{
		_UIController = FindObjectOfType<UIController>();
		_eventController = FindObjectOfType<EventController>();
	}
	
	private void Start()
	{
		_asteroidList = _eventController.AsteroidList;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.GetComponent<Bullet>())
		{
			if (_size > 0)
			{
				Vector3 lastVel = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
				Vector3 rght = Quaternion.AngleAxis(45, Vector3.forward) * lastVel;
				Vector3 left = Quaternion.AngleAxis(-45, Vector3.forward) * lastVel;

				GameObject obj = Instantiate(_asteroidList[_size - 1], gameObject.transform.position, Quaternion.identity); //45 в одну 
				obj.GetComponent<Rigidbody2D>().velocity = rght * _asteroidSpeed * Random.Range(0.2f, 1.5f);

				obj = Instantiate(_asteroidList[_size - 1], gameObject.transform.position, Quaternion.identity); //45 в другую
				obj.GetComponent<Rigidbody2D>().velocity = left * _asteroidSpeed * Random.Range(0.2f, 1.5f);
			}
			_UIController.ScoreCounter(_getPoints);

			Destroy(collision.gameObject);
			Destroy(gameObject);

			_eventController.RespawnAndNextLevel(FindObjectsOfType<Asteroid>().Length - 1);
		}

		else if (collision.GetComponent<UFO>())
		{
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
