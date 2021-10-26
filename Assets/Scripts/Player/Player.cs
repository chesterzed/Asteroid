using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
	protected Animator animator;

	[SerializeField] private UIController _UIController;

	private float _timer = 0;

    private void Start()
	{
		gameObject.transform.position = new Vector3(0, 0, 0);
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

		animator = GetComponent<Animator>();
		_UIController = FindObjectOfType<UIController>();
	}

	private void Update()
	{
		_timer += Time.deltaTime;
		ExitFromInvulnerability();
	}

	public void ApplyDamage()
	{
		if (_timer > 3)
		{
			_UIController.NowHP--;
			_UIController.HealthCounter(_UIController.NowHP);

			if (_UIController.NowHP <= 0)
			{
				_UIController.ShowMenu(true, false);
			}
			else
			{
				_timer = 0;
				gameObject.transform.position = new Vector3(0, 0, 0);
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
				animator.SetTrigger("Hit");
			}
		}

	}

	private void ExitFromInvulnerability()
	{
		if (_timer > 3)
			animator.SetBool("Invulnerability", false);
		else
			animator.SetBool("Invulnerability", true);
	}
}
