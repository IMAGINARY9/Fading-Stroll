using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LuminousBody : InteractiveBody
{
    [SerializeField] private Light2D _light;

    protected override void LateAwake()
    {
        _light.pointLightOuterRadius = transform.localScale.z;
        Instantiate(_light, transform.position, Quaternion.identity, transform);
    }

}
