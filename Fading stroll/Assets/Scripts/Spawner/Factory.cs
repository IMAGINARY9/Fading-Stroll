using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Factory
{
    [SerializeField] private BodySpawnType[] _bodies;

    public GameObject GetBody()
    {
        float chance = UnityEngine.Random.value;

        foreach (var body in _bodies)
            if (CheckRange(body, chance)) return body.Prefab;
        
        return null;
    }

    private bool CheckRange(BodySpawnType body, float chance) =>
        chance >= body.Range.x && chance < body.Range.y;
}


