using System.Collections;
using UnityEngine;
public class PlayerSetup : InteractiveBody
{
    //[SerializeField, Range(1, 5)] private float _level;
    [SerializeField] private PlayerLevel _level;

    protected override void OnAwake()
    {
        var size = _level.Level >= 1f ? _level.Level : 1f;
        transform.localScale = new Vector3(size, size, size);

        var col = GetComponent<CircleCollider2D>();
        col.density = (size * 5) + 5;
    }

}