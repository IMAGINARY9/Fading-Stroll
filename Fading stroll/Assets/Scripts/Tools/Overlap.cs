using System.Collections;
using UnityEngine;

public class Overlap : MonoBehaviour
{
    [SerializeField] private float _radius;
    public float Radius { get => _radius; set => _radius = value; }

    public Collider2D GetCollider() =>
        Physics2D.OverlapCircle(transform.position, Radius);
    public Collider2D[] GetColliders() =>
        Physics2D.OverlapCircleAll(transform.position, Radius);
    public bool CheckCollider() =>
        Physics2D.OverlapCircle(transform.position, Radius) != null;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}