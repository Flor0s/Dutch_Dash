using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90);
    }
}