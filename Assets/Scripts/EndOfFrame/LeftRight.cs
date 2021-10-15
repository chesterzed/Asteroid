using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    private Transform _outObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _outObj = collision.GetComponent<Transform>();
        _outObj.position = new Vector2(-(Mathf.Sign(_outObj.position.x) * (Mathf.Abs(_outObj.position.x) - 0.1f)), _outObj.position.y);
    }
}
