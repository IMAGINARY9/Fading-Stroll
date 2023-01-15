using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpawnersContainer))]
public class SpawnersController : MonoCache
{
    [SerializeField] private PlayerMove _player;
    [SerializeField] private float _distance;
    [SerializeField] private float _angle;
    private SpawnersContainer _sc;
    private void Start() => _sc = GetComponent<SpawnersContainer>();
    public override void OnTick()
    {
        if (_player == null) { Destroy(gameObject); return; }

        if (_player.Path != Vector2.zero && _sc.Spawners != null)
            for (int i = 0; i < _sc.Spawners.Length; i++)
                _sc.Spawners[i].position = QuaternCalc(i);
    }

    Vector2 QuaternCalc(int i)
    {
        Quaternion positionRotation = Quaternion.Euler(0, 0, i - _sc.Spawners.Length * 0.5f + 0.5f);
        positionRotation.z *= _angle;
        return _player.transform.position + positionRotation
            * _player.Path * _distance;
    }
}
