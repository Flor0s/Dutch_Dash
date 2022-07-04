using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewSection2 : MonoBehaviour
{
    public Transform SpawnLocation;
    public Transform Parent;

    public GameObject[] Sections;

    // how far away the other platform spawns
    //public float SectionSpawnDistance = 0;

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            //TO ADD Object Pooling
            Instantiate(Sections[Random.Range(0, Sections.Length)], SpawnLocation.position, Quaternion.identity, Parent);
            TempoRegulator.Instance.UpdateChunkcount(1);
        }
    }

    private void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            //put code here to return to object pool
            Destroy(gameObject);
        }
    }
}