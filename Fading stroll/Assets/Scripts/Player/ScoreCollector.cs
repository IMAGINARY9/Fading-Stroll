using System.Collections;
using UnityEngine;

public class ScoreCollector : MonoCache
{
    [SerializeField] private DataHolder _score;
    public void AddScore(float value) => _score.Score += (int)(value * 10f);
}
