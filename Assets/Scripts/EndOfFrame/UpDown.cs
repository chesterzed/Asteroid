using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    private Transform _outObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _outObj = collision.GetComponent<Transform>();
        _outObj.position = new Vector2(_outObj.position.x, -(Mathf.Sign(_outObj.position.y) * (Mathf.Abs(_outObj.position.y) - 0.1f)));

        
    }

}
