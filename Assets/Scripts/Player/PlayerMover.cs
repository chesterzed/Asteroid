using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	[SerializeField] private Movers_SO _moversSO;
	[SerializeField] private AudioSource _shootSound;
	[SerializeField] private AudioSource _moveSound;

	private Rigidbody2D rb;

	private Vector3 playerLook;
	private float _degree;
	private float _horizontal;
	private float _timer;
	private float angle;
	private float sign;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void MoveForward(bool isMoving)
	{
		if (isMoving)
		{
			_moveSound.PlayOneShot(_moveSound.clip);
			_timer += Time.fixedDeltaTime * _moversSO.AccelerationFactor;

			if (_timer > 1)
				_timer = 1;

			rb.velocity = transform.up * _moversSO.MaxSpeed * Time.fixedDeltaTime * Mathf.Lerp(0, _moversSO.MaxSpeed, _timer);
		}
		else
		{
			_timer = 0;
		}
	}

	public void Rotate(int choice)
	{
        if (choice == 0)
        {
            _horizontal = Input.GetAxis("Horizontal");
            _degree += _horizontal * Time.fixedDeltaTime * -_moversSO.RotationKeyboardSpeed;
        }
        else if (choice == 1)
        {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			playerLook = (mousePos - transform.position).normalized;
			playerLook.z = 0;

			angle = Vector3.Angle(Vector3.up, playerLook);
			sign = Mathf.Sign(Vector3.Dot(Vector3.forward, Vector3.Cross(Vector3.up, playerLook)));
			
			_degree = Mathf.LerpAngle(_degree, angle * sign, Time.fixedDeltaTime * _moversSO.RotationMouseSpeed);
		}
		rb.MoveRotation(_degree);
	}

	public void Shoot()
	{
		_shootSound.Play();
		Instantiate(_moversSO.BulletsPrefab[0], transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(transform.up * _moversSO.BulletSpeed, ForceMode2D.Force);
	}
}
