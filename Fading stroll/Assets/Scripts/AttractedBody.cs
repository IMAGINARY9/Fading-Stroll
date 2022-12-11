﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AttractedBody : ExplosiveBody, IAttracted
{
    public const float G = 0.00667f;
    public void Attract(float mass, float dist, Vector2 dir)
    {
        if (rb == null) return;
        float F = G * (rb.mass * mass / dist);
        rb.AddForce(F * -dir);
    }

    [Obsolete]
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.TryGetComponent<ExplosiveBody>(out var body))
            if (body.Mass >= rb.mass) Explode();
    }
}

