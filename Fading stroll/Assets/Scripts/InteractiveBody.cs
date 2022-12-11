using System.Collections;
using UnityEngine;

public abstract class InteractiveBody : MonoCache
{
    protected Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        OnAwake();
        rb.AddForce(Vect.RandomVector * Random.Range(1f, transform.localScale.z * 10f), ForceMode2D.Impulse);
        Invoke(nameof(LateAwake), 0.1f);
    }
    protected virtual void OnAwake() { }
    protected virtual void LateAwake() { }
}
