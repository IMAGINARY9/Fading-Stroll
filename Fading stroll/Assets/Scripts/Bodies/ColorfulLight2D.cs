using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ColorfulLight2D : MonoBehaviour
{
    [SerializeField] private Vector2 _colorRange;
    private void Awake() => 
        GetComponent<Light2D>().color = new Color(Rand(), Rand(), Rand());
    private float Rand() => Random.Range(_colorRange.x, _colorRange.y);
}
