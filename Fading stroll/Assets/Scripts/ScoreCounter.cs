using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoCache
{
    [SerializeField] private TextMeshProUGUI _counter;
    public float Score { get; set; }

    private void Start()
    {
        Score = 0;
    }

    public override void OnTick()
    {
        Score += Time.deltaTime * 2f;
        _counter.SetText(((int)Score).ToString());
    }
}
