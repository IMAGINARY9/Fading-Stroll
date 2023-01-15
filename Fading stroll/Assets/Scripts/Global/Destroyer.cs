using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoCache
{
    public static List<GameObject> allDestroy = new();
    [SerializeField] private GameObject _player;
    [SerializeField] private float _destroyDistance;
    private Vector3 _playerPos;
    public int Count;

    public override void OnTick()
    {
        Count = allDestroy.Count;
        if(_player != null) _playerPos = _player.transform.position;
        for (int i = 0; i < allDestroy.Count; i++)
        {
            if (allDestroy[i] == null)
            {
                allDestroy.Remove(allDestroy[i]);
                return;
            }
            var dist = Vector2.Distance(allDestroy[i].transform.position, _playerPos);
            if(dist >= _destroyDistance)
            {
                Destroy(allDestroy[i]);
                allDestroy.Remove(allDestroy[i]);
            }
        }
    }
}
