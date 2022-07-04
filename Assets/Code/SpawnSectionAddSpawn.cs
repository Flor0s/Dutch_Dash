using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSectionAddSpawn : MonoBehaviour
{
    public GameObject[] Sections;
    public Transform Parent;
    public Transform SpawnLocation;

    // Start is called before the first frame update
    private void Start()
    {
        Instantiate(Sections[Random.Range(0, Sections.Length)], SpawnLocation.position, Quaternion.identity, Parent);
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
}