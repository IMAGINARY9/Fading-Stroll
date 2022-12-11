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
    //public override void OnTick()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //        Spawn();

    //}

    private void Spawn()
    {
        GameObject obj = _prefabs[Random.Range(0, _prefabs.Length)];
        Vector3 currentPos = transform.position;
        Vector2 newPos = new Vector2(Random.Range(_size.x, _size.y) + currentPos.x,
            Random.Range(_size.x, _size.y) + currentPos.y);
        var newObj = Instantiate(obj, newPos, Quaternion.identity);
        Destroyer.allDestroy.Add(newObj);
    }

}
