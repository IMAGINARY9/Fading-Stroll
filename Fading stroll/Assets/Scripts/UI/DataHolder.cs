using System.Collections;
using TMPro;
using UnityEngine;

public class DataHolder : MonoCache
{
    [SerializeField] private TextMeshProUGUI _counter;
    private int _score;
    private float _level;
    public float Level
    {
        get => _level;
        set
        {
            _level = value; 
            Save();
        }
    }
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            ScoreUIUpdate(_score);
        }
    }
    private void Awake() => Load();
    private void Start() => PlayerInfo.PlayerDestroy += OnPlayerDestroy;
    public void ScoreUIUpdate(int score) => _counter.SetText((score).ToString());
    private void OnPlayerDestroy()
    {
        Save();
        PlayerInfo.PlayerDestroy -= OnPlayerDestroy;
    }
    private void Save() => SaveSystem.SaveData(this);
    private void Load()
    {
        var data = SaveSystem.LoadData();
        Score = data == null ? 0 : data.Score;
        Level = data == null ? 1f : data.Level;
    }
    public void ResetScore()
    {
        Score = 0;
        Save();
    }
}
