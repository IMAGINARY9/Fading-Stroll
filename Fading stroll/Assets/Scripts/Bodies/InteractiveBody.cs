using System.Collections;
using UnityEngine;

public abstract class InteractiveBody : MonoCache
{
    protected Rigidbody2D rb;
    public float Mass => rb.mass;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        OnAwake();
        Dash();
        Invoke(nameof(LateAwake), 0.1f);
    }
    public void Dash() => 
        rb.AddForce(Vect.RandomVector * Random.Range(1f, transform.localScale.z * Mass), ForceMode2D.Impulse);
    public void PowerDash() => 
        rb.AddForce(Vect.RandomVector * Random.Range(1f, transform.localScale.z * Mass) * 2, ForceMode2D.Impulse);
    protected virtual void OnAwake() { }
    protected virtual void LateAwake() { }
}
