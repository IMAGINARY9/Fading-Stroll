using System.Collections;
using UnityEngine;

public class ExplosiveBody : InteractiveBody
{
    [SerializeField] protected ParticleSystem destroyParticles;

    [System.Obsolete]
    protected void Explode()
    {
        Particles();
        Destroy(gameObject);
    }
    [System.Obsolete]
    private void Particles()
    {
        var particles = Instantiate(destroyParticles, transform.position, Quaternion.identity);
        var scale = transform.localScale.z;

        var pShape = particles.shape;
        pShape.radius = scale;

        var pCount = (short)(Mass * 100);
        var pBurst = new ParticleSystem.Burst(0f, pCount >= 0 ? pCount : short.MaxValue);

        particles.emission.SetBurst(0, pBurst);

        particles.startSize = scale * 0.2f;

        particles.Play();
        Destroy(particles.gameObject, particles.startLifetime);
    }
}
