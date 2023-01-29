using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class ProgressData
{
    public bool Mute { get; private set; }
    public int Score { get; private set; }
    public float Level { get; private set; }

    public ProgressData(DataHolder data)
    {
        Mute = data.Mute;
        Score = data.Score;
        Level = data.Level;
    }
}
