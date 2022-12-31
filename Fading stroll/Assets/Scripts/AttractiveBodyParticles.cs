using System.Collections;
using UnityEngine;

public class AttractiveBodyParticles : InteractiveBody
{
    [SerializeField] private ParticleSystem _attractiveParticles;

    public void Particles(float radius)
    {
        var particles = Instantiate(_attractiveParticles, transform.position, Quaternion.identity, transform);

        var pMain = particles.main;
        pMain.startSize = radius * 0.0125f;
        pMain.startLifetime = radius * 0.1f;
        pMain.startSpeed = -radius * 0.5f;

        var pShape = particles.shape;
        pShape.radius = radius;
        

        particles.Play();
    }

}
