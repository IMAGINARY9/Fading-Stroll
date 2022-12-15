using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractiveBody : InteractiveBody
{
    [SerializeField] private Overlap _attractionZone;
    [SerializeField] private ParticleSystem _attractiveParticles;

    protected override void LateAwake()
    {
        var radius = (rb.mass * 0.1f) + (transform.localScale.z * 10f);
        _attractionZone.Radius = radius;

        Particles(radius);
    }

    private void Particles(float radius)
    {
        var particles = Instantiate(_attractiveParticles, transform.position, Quaternion.identity, transform);
        var pShape = particles.shape;
        pShape.radius = radius;
        particles.Play();
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

