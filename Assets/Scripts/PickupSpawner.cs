using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public List<Transform> PossibleSpawnPoints;
    public List<GameObject> Pickups;

    private void Start()
    {
        for (int i = 0; i < PossibleSpawnPoints.Count; i++)
        {
            int chanceroll = Random.Range(0, 100);
            Debug.Log(chanceroll);

            if (chanceroll <= 35)
            {
                //spawn coin(s)
                Instantiate(Pickups[0].gameObject, PossibleSpawnPoints[i].position, Quaternion.LookRotation(Vector3.forward));
                Instantiate(Pickups[0].gameObject, new Vector3(PossibleSpawnPoints[i].position.x - 1, PossibleSpawnPoints[i].position.y, PossibleSpawnPoints[i].position.z), Quaternion.LookRotation(Vector3.forward));
                Instantiate(Pickups[0].gameObject, new Vector3(PossibleSpawnPoints[i].position.x - 2, PossibleSpawnPoints[i].position.y, PossibleSpawnPoints[i].position.z), Quaternion.LookRotation(Vector3.forward));
            }
            else if (chanceroll > 35 && chanceroll <= 55)
            {
                //spawn score multiplier
                Instantiate(Pickups[2].gameObject, PossibleSpawnPoints[i].position, Quaternion.identity);
            }
            else if (chanceroll > 55 && chanceroll <= 65)
            {
                //spawn shield
                Instantiate(Pickups[1].gameObject, PossibleSpawnPoints[i].position, Quaternion.LookRotation(Vector3.forward));
            }
        }
    }
}