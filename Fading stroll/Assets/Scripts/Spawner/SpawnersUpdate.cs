using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpawnersContainer))]
public class SpawnersUpdate : MonoCache
{
    [SerializeField] private Transform _container;
    [SerializeField] private Factory _factory;
    [SerializeField] private float _tickRate;
    [Header("PreSpawn")]
    [SerializeField] private float _safeSize;
    [SerializeField] private int _startCount;
    private SpawnersContainer _sc;
    private void Start()
    {
        _sc = GetComponent<SpawnersContainer>();
        PreSpawn();
        InvokeRepeating(nameof(NewSpawn), 3, _tickRate);
    }

    private void PreSpawn()
    {
        var startSize = _safeSize * 10f;
        for (int i = 0; i < _startCount; i++)
        {
            Vector2 newPos = new(Random.Range(-startSize, startSize),
                Random.Range(-startSize, startSize));
            if (Mathf.Abs(newPos.x) < _safeSize || Mathf.Abs(newPos.y) < _safeSize)
            {
                i--;
                continue;
            }
            Spawn(newPos);
        }
    }

    private void NewSpawn()
    {
        if (_sc.Spawners != null)
            foreach (Transform spawner in _sc.Spawners)
            {
                Vector3 currentPos = spawner.position;
                float size = spawner.transform.localScale.z * 0.5f;
                Vector2 newPos = new(Random.Range(-size, size) + currentPos.x,
                    Random.Range(-size, size) + currentPos.y);
                Spawn(newPos);
            }
    }

    private void Spawn(Vector2 pos)
    {
        GameObject obj = _factory.GetBody();
        var newObj = Instantiate(obj, pos, Quaternion.identity, _container);
        Destroyer.allDestroy.Add(newObj);
    }

}
