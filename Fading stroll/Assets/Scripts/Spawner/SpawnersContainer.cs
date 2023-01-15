using System.Collections;
using System.Linq;
using UnityEngine;

public class SpawnersContainer : MonoCache
{
    private Transform[] _spawners;
    public Transform[] Spawners { get => _spawners; set => _spawners = value; }
    private void Start() => Spawners = GetComponentsInChildren<Transform>().Skip(1).ToArray();
}
