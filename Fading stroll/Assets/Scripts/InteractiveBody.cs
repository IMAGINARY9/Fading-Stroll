using System.Collections;
using UnityEngine;

public abstract class InteractiveBody : MonoCache
{
    protected Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
