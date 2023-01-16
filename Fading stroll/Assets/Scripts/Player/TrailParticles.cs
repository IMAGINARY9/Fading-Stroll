using System.Collections;
using UnityEngine;

public class TrailParticles : MonoCache
{
    [SerializeField] private ParticleSystem _trail;

    private void Awake() => Invoke(nameof(ParticlesSetup), 0.5f);

    [System.Obsolete]
    private void ParticlesSetup()
    {
        _trail.startSize = transform.localScale.z * 0.1f;
        var tShape = _trail.shape;
        tShape.radius = transform.localScale.z * 0.5f;
    }
}
