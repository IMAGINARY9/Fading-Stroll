using System.Collections;
using UnityEngine;

public class BackgroundOpening : MonoCache
{
    void Start() => transform.Rotate(0, 0, Random.Range(0, 4) * 90f);

}
