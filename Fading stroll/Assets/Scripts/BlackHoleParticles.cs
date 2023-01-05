using System.Collections;
using UnityEngine;

public class BlackHoleParticles : AttractiveBodyParticles
{
    public override void Particles(float radius)
    {
        var particles = Instantiate(_particles, transform.position, Quaternion.identity, transform);

        var pMain = particles.main;
        pMain.startSize = radius * 0.05f;
        pMain.startLifetime = radius * 0.1f;
        pMain.startSpeed = -radius * 0.25f;

        var pShape = particles.shape;
        pShape.radius = radius * 0.25f;


        particles.Play();
    }

}