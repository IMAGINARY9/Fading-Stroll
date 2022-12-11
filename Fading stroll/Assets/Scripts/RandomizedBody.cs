using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class RandomizedBody : InteractiveBody
    {
        [SerializeField] private Vector2 _sizeLim;
        [SerializeField] private Vector2 _densityLim;

        protected override void OnAwake()
        {
            var col = GetComponent<CircleCollider2D>();
            col.density = Random.Range(_densityLim.x, _densityLim.y);

            var size = Random.Range(_sizeLim.x, _sizeLim.y);
            transform.localScale = new Vector3(size, size, size);
        }
    }
}