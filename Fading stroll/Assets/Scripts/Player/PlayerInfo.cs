using System;
using System.Collections;
using UnityEngine;

public class PlayerInfo : MonoCache
{
    [SerializeField] private DataHolder _levelHolder;
    public float Level => _levelHolder.Level; 

    public static Action PlayerDestroy;
    private void OnDestroy() => PlayerDestroy?.Invoke();
}