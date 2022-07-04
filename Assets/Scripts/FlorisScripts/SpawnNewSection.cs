using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewSection : MonoBehaviour
{
    public GameObject[] Sections;
    public Transform Parent;

    // how far away the other platform spawns
    public float SectionSpawnDistance = 0;

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            Debug.Log("Entered colider");
            //instantiate add (x = ssd, y = 0, z = 0)
            //TO ADD Object Pooling
            Instantiate(Sections[Random.Range(0, Sections.Length)], new Vector3(gameObject.transform.position.x + SectionSpawnDistance, gameObject.transform.position.y - 0.0001f, 0), Quaternion.identity, Parent);
        }
    }

    private void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            Debug.Log("Exited colider");
            //put code here to return to object pool
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("destroyed");
    }
}