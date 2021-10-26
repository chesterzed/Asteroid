using UnityEngine;

[RequireComponent(typeof(PlayerMover))] 
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private UIController _UIController;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && _timer > 0.3f)
        {
            _timer = 0;
            _playerMover.Shoot();
        }
    }
    
    private void FixedUpdate()
    {
        _playerMover.Rotate(_UIController.PlayerChoice);

        if (Input.GetKey(KeyCode.W))
            _playerMover.MoveForward(true);
        else
            _playerMover.MoveForward(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Asteroid>())
            _player.ApplyDamage();
        else if (collision.GetComponent<UFOBullet>() || collision.GetComponent<UFO>())
        {
            _player.ApplyDamage();
            Destroy(collision.gameObject);
        }
    }
}
