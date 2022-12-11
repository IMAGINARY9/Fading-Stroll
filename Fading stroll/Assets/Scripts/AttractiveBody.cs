using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractiveBody : InteractiveBody
{
    [SerializeField] private Overlap _attractionZone;

    protected override void LateAwake()
    {
        _attractionZone.Radius = (rb.mass * 0.1f) + (transform.localScale.z * 10f);
    }
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
                if (rb == null) return;
                entity.Attract(rb.mass, dist, dir);
            }

        }
    }
    
}

