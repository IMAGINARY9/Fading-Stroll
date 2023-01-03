using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractiveBody : InteractiveBody
{
    [SerializeField] private Overlap _attractionZone;
    protected override void LateAwake()
    {
        var radius = 4f * (float)Math.Log(rb.mass) - 2f;
        _attractionZone.Radius = radius;

        if(TryGetComponent<AttractiveBodyParticles>(out var particles))
            particles.Particles(radius);
    }


    public override void OnFixedTick()
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

    private void OnEnable() => AddFixedUpdate();
    private void OnDisable() => RemoveFixedUpdate();
    private void OnDestroy() => RemoveFixedUpdate();

}

