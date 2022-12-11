using System.Collections;
using UnityEngine;

public class SpawnerController : MonoCache
{
    [SerializeField] private PlayerMove _player;
    [SerializeField] private float _distance;
    public override void OnTick()
    {
        if(_player.Path != Vector2.zero)
            transform.localPosition = _player.Path.normalized * _distance;
    }
}
