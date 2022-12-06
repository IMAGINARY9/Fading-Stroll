using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AttractedBody : InteractiveBody, IAttracted
{
    public const float G = 0.00667f;
    public void Attract(float mass, float dist, Vector2 dir)
    {
        float F = G * ((rb.mass * mass) / dist);
        rb.AddForce(F * -dir);
    }
}

