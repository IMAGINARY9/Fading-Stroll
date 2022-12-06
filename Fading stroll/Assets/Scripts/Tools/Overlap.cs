using System.Collections;
using UnityEngine;

public class Overlap : MonoBehaviour
{
    [SerializeField] private float _radius;

    public Collider2D GetCollider() =>
        Physics2D.OverlapCircle(transform.position, _radius);
    public Collider2D[] GetColliders() =>
        Physics2D.OverlapCircleAll(transform.position, _radius);
    public bool CheckCollider() =>
        Physics2D.OverlapCircle(transform.position, _radius) != null;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}