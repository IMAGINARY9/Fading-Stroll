using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DataHolder : MonoCache
{
    private bool _mute;
    private int _score;
    private float _level;
    public Action LevelChanged;
    public Action ScoreChanged;

    public bool Mute 
    { 
        get => _mute; 
        set 
        {
            _mute = value;
            Save();
        } 
    }

    public float Level
    {
        get => _level;
        set
        {
            _level = value >= 5 ? 5 : value <= 1 ? 1 : value;
            Save();
            LevelChanged?.Invoke();
        }
    }
    public int Score
    {
        get => _score;
        set
        {
            _score = value >= 0 ? value : 0;
            ScoreChanged?.Invoke();
        }
    }
    private void Awake() => Load();
    private void Start() => PlayerInfo.PlayerDestroy += OnPlayerDestroy;
    private void OnPlayerDestroy()
    {
        Save();
        PlayerInfo.PlayerDestroy -= OnPlayerDestroy;
    }
    private void Save() => SaveSystem.SaveData(this);
    private void Load()
    {
        var data = SaveSystem.LoadData();
        Mute = data == null || data.Mute;
        Score = data == null ? 0 : data.Score;
        Level = data == null ? 1f : data.Level;
    }
    public void ResetData()
    {
        Score = 0;
        Level = 1;
    }
}
