using System.Collections;
using UnityEngine;

public class ColorfulBody : InteractiveBody
{
    [SerializeField] private float _colorRange;

    protected override void OnAwake()
    {
        var sp = GetComponent<SpriteRenderer>();
        var color = sp.color;

        color.r += Random.Range(-_colorRange, _colorRange);
        color.g += Random.Range(-_colorRange, _colorRange);
        color.b += Random.Range(-_colorRange, _colorRange);

        sp.color = color;

    }
}
