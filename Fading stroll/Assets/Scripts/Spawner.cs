using System.Collections;
using UnityEngine;

public class Spawner : MonoCache
{
    [SerializeField] private Transform _container;
    [SerializeField] private Factory _factory;
    [SerializeField] private float _size;
    [SerializeField] private float _safeSize;
    [SerializeField] private int _startCount;
    [SerializeField] private float _tickRate;

    void Start()
    {
        var startSize = _safeSize * 5f;
        for (int i = 0; i < _startCount; i++)
        {
            Vector2 newPos = new(Random.Range(-startSize, startSize),
                Random.Range(-startSize, startSize));
            if(Mathf.Abs(newPos.x) < _safeSize || Mathf.Abs(newPos.y) < _safeSize)
            {
                i--; 
                continue;
            }
            Spawn(newPos);
        }
        InvokeRepeating(nameof(NewPos), 1, _tickRate);
    }
    //public override void OnTick()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //        Spawn();
    //}
    private void NewPos()
    {
        Vector3 currentPos = transform.position;
        Vector2 newPos = new(Random.Range(-_size, _size) + currentPos.x,
            Random.Range(-_size, _size) + currentPos.y);
        Spawn(newPos);
    }

    private void Spawn(Vector2 pos)
    {
        GameObject obj = _factory.GetBody();
        var newObj = Instantiate(obj, pos, Quaternion.identity, _container);
        Destroyer.allDestroy.Add(newObj);
    }


}
