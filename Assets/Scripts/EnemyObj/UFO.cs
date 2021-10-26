using UnityEngine;

[RequireComponent(typeof(UFOMover))]
public class UFO : MonoBehaviour
{
	[SerializeField] private UFO_SO _UFO_SO;
	[SerializeField] private AudioSource _shootSound;

	private AudioSource _errorSound;
	private UIController _UIController;
	private UFOMover _mover;
	private float _switchDirTimer;
	private float _shootTime;
	private float _timer = 0;

    private void Awake()
    {
		_errorSound = FindObjectOfType<ErrorSoundUFO>().GetComponent<AudioSource>();
		_UIController = FindObjectOfType<UIController>();
		_mover = GetComponent<UFOMover>();
	}

	private void OnEnable()
	{

		_shootTime = Random.Range(0f, 4f);

		float side = -Mathf.Sign(transform.position.x);
		_mover.SwitchDirection(0, side);
	}

	private void Update()
	{
		_timer += Time.deltaTime;
		_switchDirTimer += Time.deltaTime;

		if (_timer > _shootTime)
		{
			_timer = 0;
			_mover.Shoot();
			_shootTime = Random.Range(0.5f, 4f);
			_shootSound.Play();
		}

		if (_switchDirTimer > _UFO_SO.SwitchDirTime)
		{
			_switchDirTimer = 0;
			int rand = new System.Random().Next(-1, 1);
			_mover.SwitchDirection(rand, 0);
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Bullet>())
		{
			_errorSound.Play();
			_UIController.ScoreCounter(_UFO_SO.GetPoints);
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
