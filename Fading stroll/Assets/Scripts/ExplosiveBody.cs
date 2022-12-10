﻿using System.Collections;
using UnityEngine;

public class ExplosiveBody : InteractiveBody
{
    [SerializeField] protected ParticleSystem destroyParticles;
    public float Mass => rb.mass;

    [System.Obsolete]
    private void OnDestroy()
    {
        var particles = Instantiate(destroyParticles, transform.position, Quaternion.identity);
        particles.Play();
        Destroy(particles.gameObject, particles.startLifetime);
    }
}