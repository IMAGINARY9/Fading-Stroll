using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class ProgressData
{
    public int Score { get; private set; }
    public float Level { get; private set; }

    public ProgressData(DataHolder data)
    {
        Score = data.Score;
        Level = data.Level;
    }
}
