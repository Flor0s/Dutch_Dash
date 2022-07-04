using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterEvent : MonoBehaviour
{
    [SerializeField] private float startEventTimer = 0;
    [SerializeField] private float TimerEnd = 10;
    [SerializeField] private bool waveIncomming;

    public int selectedLine;
    public int waveLength = 5;
    public float waveTimer = 0;
    public bool Wave = false;

    public GameObject[] Waves;

    // Start is called before the first frame update
    void Start()
    {
        Waves = GameObject.FindGameObjectsWithTag("Wave");
    }

    // Update is called once per frame
    void Update()
    {
        startEventTimer += Time.deltaTime;

        if (Wave)
        {
            waveTimer += Time.deltaTime;
        }

        if (startEventTimer >= TimerEnd)
        {
            Event();
            startEventTimer = 0;
        }
        Debug.Log("timer = " + startEventTimer);

        if (waveTimer >= waveLength)
        {
            GoDown();
        }
    }

    void Event()
    {
        selectedLine = Random.Range(0, Waves.Length);

        Waves[selectedLine].transform.position = new Vector3(Waves[selectedLine].transform.position.x, Waves[selectedLine].transform.position.y + 2, Waves[selectedLine].transform.position.z);
        Wave = true;
    }

    void GoDown()
    {
        Waves[selectedLine].transform.position = new Vector3(Waves[selectedLine].transform.position.x, Waves[selectedLine].transform.position.y - 2, Waves[selectedLine].transform.position.z);
        Wave = false;
        waveTimer = 0;
        startEventTimer = 0;
    }
}
