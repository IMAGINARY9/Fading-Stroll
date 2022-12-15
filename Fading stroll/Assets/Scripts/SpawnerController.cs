using System.Collections;
using UnityEngine;

public class SpawnerController : MonoCache
{
    [SerializeField] private PlayerMove _player;
    [SerializeField] private float _distance;
    public override void OnTick()
    {
        if (_player == null) { Destroy(gameObject); return; }
        if (_player.Path != Vector2.zero)
            transform.position = _player.transform.position + (Vector3)_player.Path * _distance;
    }
}
