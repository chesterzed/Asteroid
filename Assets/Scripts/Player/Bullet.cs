using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Movers_SO _mover;
    private float _timer = 0;
    private float _lifeTime;

    private void OnEnable()
    {
        CheckScreen();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _lifeTime)
            Destroy(gameObject);
    }

    private void CheckScreen()
    {
        float camHalfHeight = Camera.main.orthographicSize;
        float camHalfWidth = Camera.main.aspect * camHalfHeight;

        _lifeTime = (camHalfWidth) / (_mover.BulletSpeed / 100);
    }
}
