using System.Collections;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoCache
{
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private float _updateUIRate;
    private float _updateRate;
    public int FPS { get; private set; }

    private void Start() => _updateRate = _updateUIRate;
    public override void OnTick()
    {
        if((_updateRate -= Time.deltaTime) <= 0)
        {
            FPS = (int)(1 / Time.deltaTime);
            _counter.SetText(FPS.ToString());
            _updateRate = _updateUIRate;
        }
    }
}
