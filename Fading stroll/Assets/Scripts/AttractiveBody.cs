using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractiveBody : AttractedBody
{
    [SerializeField] private Overlap _attractionZone;

    public override void OnTick()
    {
        Collider2D[] objs = _attractionZone.GetColliders();
        if (objs == null) return;

        foreach (var obj in objs)
        {
            if (obj.gameObject == gameObject) continue;

            if (obj.TryGetComponent<IAttracted>(out var entity))
            {
                var dist = Vector2.Distance(obj.transform.position, transform.position);
                var dir = obj.transform.position - transform.position;
                entity.Attract(rb.mass, dist, dir);
            }

        }
    }
    
}

