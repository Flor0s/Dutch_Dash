using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePowerUp : MonoBehaviour
{

    public bool powerup;
    public float timer = 10;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreUp"))
        {
            powerup = true;
            other.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (powerup)
        {   
            //score x2
            ScoreSystem.instance.ScoreMod = 2;
            timer -= 1 * Time.deltaTime;
        }

        if (timer <= 0)
        {
            powerup = false;
            ScoreSystem.instance.ScoreMod = 1;
            timer = 10;
        }
    }
}
