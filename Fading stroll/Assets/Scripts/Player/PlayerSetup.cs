using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInfo))]
public class PlayerSetup : InteractiveBody
{
    protected override void OnAwake()
    {
        var level = GetComponent<PlayerInfo>().Level;

        var size = level >= 1f && level <= 5f ? level : 1f;
        transform.localScale = new Vector3(size, size, size);

        var col = GetComponent<CircleCollider2D>();
        col.density = (size * 5) + 5;
    }

}