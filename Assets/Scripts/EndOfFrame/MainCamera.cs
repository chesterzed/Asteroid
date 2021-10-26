using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position = new Vector3(0, 0, -10);
    }
}
