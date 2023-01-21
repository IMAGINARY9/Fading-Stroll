using System;
using System.Collections;
using UnityEngine;

public class PlayerInfo : MonoCache, IScoreCollector
{
    [SerializeField] private DataHolder _dataHolder;
    public float Level => _dataHolder.Level; 

    public static Action PlayerDestroy;
    private void OnDestroy() => PlayerDestroy?.Invoke();
    public void AddScore(float value) => _dataHolder.Score += (int)(value * 10f);
}