using System.Collections;
using UnityEngine;

public class Spawner : MonoCache
{
    [SerializeField] private Vector2 _size;
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _tickRate;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1, _tickRate);
    }

    private void Spawn()
    {
        GameObject obj = _prefabs[Random.Range(0, _prefabs.Length)];
        Vector3 pos = new Vector2(Random.Range(_size.x, _size.y), Random.Range(_size.x, _size.y));
        Instantiate(obj, pos + transform.localPosition, Quaternion.identity);
    }

}
