using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBullet : MonoBehaviour
{
    [SerializeField] private Movers_SO _mover;
    private float _lifeTime = 3;
    private float _timer = 0;

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
