using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class BodySpawnType 
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector2 _range;
    public GameObject Prefab => _prefab;
    public Vector2 Range => _range;

}
