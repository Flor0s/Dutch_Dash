using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public float ScoreMod;

    public static ScoreSystem instance;

    public float m_coins;
    public AudioSource coinsound;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] public float m_totalScore;
    [SerializeField] public TMP_Text score_text;
    [SerializeField] private TMP_Text coins_text;

    private Vector3 m_oldPosisition;
    private float m_totalDistance;

    private void Start()
    {
        m_oldPosisition = transform.position;
    }

    private void Update()
    {
        CalculateDistance(m_coins);
    }

    private void CalculateDistance(float _coins)
    {
        Vector3 _distancevector = transform.position - m_oldPosisition;
        float _distancetravelledthisframe = _distancevector.magnitude;

        m_totalDistance += _distancetravelledthisframe;
        m_oldPosisition = transform.position;

        m_totalScore = m_totalDistance * ScoreMod * (1 + _coins);
        m_totalScore = Mathf.RoundToInt(m_totalScore);
        score_text.text = "Score: " + m_totalScore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinsound.Play();
            m_coins++;
            coins_text.text = m_coins.ToString();
            other.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("Score", Mathf.RoundToInt(m_totalScore));
        PlayerPrefs.Save();
    }
}