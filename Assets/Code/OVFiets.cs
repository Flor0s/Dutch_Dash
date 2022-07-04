using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVFiets : MonoBehaviour
{
    public bool bike;
    private float timer;

    private void Start()
    {
        bike = false;
    }
    private void Update()
    {
        if (bike)
        {
            timer -= 1 * Time.deltaTime;
        }

        if (timer <= 0)
        {
            bike = false;          
            timer = 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bike")
        {
            bike = true;
        }
    }
}
