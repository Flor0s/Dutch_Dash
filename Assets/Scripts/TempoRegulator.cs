using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoRegulator : MonoBehaviour
{
    public static TempoRegulator Instance;

    private int ChunkCount;
    private float TempoMod;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TempoMod = 1;
    }

    private void UpdateTempoMod(float _amount)
    {
        TempoMod *= _amount;
    }

    public void UpdateChunkcount(int _amount)
    {
        ChunkCount += _amount;
        if (ChunkCount % 10 == 0)
        {
            UpdateTempoMod(1.02f);
        }
    }

    public float GetTempoMod()
    {
        return TempoMod;
    }

    public float GetChunkCount()
    {
        return ChunkCount;
    }
}