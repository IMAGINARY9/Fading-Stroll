using System.Collections;
using UnityEngine;

public class ScoreCollector : MonoCache
{
    [SerializeField] private ScoreCounter _score;

    public void AddScore(float value)
    {
        _score.Score += value * 10f;
    }

}
