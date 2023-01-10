using System.Collections;
using UnityEngine;


public class CameraPointOpening : MonoCache
{
    private void Start()
    {
        transform.localPosition = Vect.RandomSimilarVector() * 10;
        StartCoroutine(PointMove());
    }

    public IEnumerator PointMove()
    {
        var tLP = transform.localPosition;
        while (Vect.LowEqual(transform.localPosition, 0))
        {
            tLP.x -= Time.deltaTime;
            tLP.y -= Time.deltaTime;
            transform.localPosition = tLP;
            yield return null;
        }
    }


}
