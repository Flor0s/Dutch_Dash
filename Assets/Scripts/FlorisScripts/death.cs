using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class death : MonoBehaviour
{
    public AudioSource audio;
    public GameObject panel;
    public AudioClip deathclip;
    public TMP_Text scoretext;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            scoretext.text = ScoreSystem.instance.m_totalScore.ToString();
            audio.clip = deathclip;
            Time.timeScale = 0f;
            panel.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scoretext.text = ScoreSystem.instance.m_totalScore.ToString();
            audio.clip = deathclip;
            Time.timeScale = 0f;
            panel.gameObject.SetActive(true);
        }
    }
}