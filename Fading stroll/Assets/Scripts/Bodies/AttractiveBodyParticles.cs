using System.Collections;
using UnityEngine;

public class AttractiveBodyParticles : InteractiveBody
{
    [SerializeField] protected ParticleSystem _particles;

    public virtual void Particles(float radius)
    {
        var particles = Instantiate(_particles, transform.position, Quaternion.identity, transform);

        var pMain = particles.main;
        pMain.startSize = radius * 0.05f;
        pMain.startLifetime = radius * 0.1f;
        pMain.startSpeed = -radius * 0.5f;

        var pShape = particles.shape;
        pShape.radius = radius * 1.25f;
        

        particles.Play();
    }

}
