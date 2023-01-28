using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(LuminousBody))]
public class FadingBody : AttractedBody
{
    [SerializeField] private float _fadingPower;
    [SerializeField] private UI _ui;

    private Coroutine _activeCoroutine;
    private Light2D _light;
    private float _lightDefaultIntensity;
    protected override void LateAwake() => Invoke(nameof(AfterLateAwake), 0.1f);
    private void AfterLateAwake()
    {
        _light = GetComponentInChildren<Light2D>();
        _lightDefaultIntensity = _light.intensity;
    }
    public override void OnTick()
    {
        if (_light == null) return;
        _ui.UpdateMoveButton(_light.intensity <= _lightDefaultIntensity * 0.8f);
        _ui.UpdateMoveText(_lightDefaultIntensity / _light.intensity * 100f);
        if (Vect.LowEqual(Vect.Abs(rb.velocity), 0.5f))
        {
            _light.intensity -= _fadingPower * Time.deltaTime;
            if (_light.intensity < 0f) Explode();
        }
        else
            _light.intensity = _lightDefaultIntensity;
    }
}
