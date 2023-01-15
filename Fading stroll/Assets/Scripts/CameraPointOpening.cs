using System.Collections;
using UnityEngine;


public class CameraPointOpening : MonoCache
{
    [SerializeField] private float _openingCoeff;

    private void Start()
    {
        transform.localPosition = Vect.RandomSimilarVector() * 10;
        CheckPosition();
    }

    private void CheckPosition()
    {
        var tLP = transform.localPosition;
        if (Vect.LowEqual(transform.localPosition, 0))
            StartCoroutine(PointMoveUP(tLP));
        else
            StartCoroutine(PointMoveDown(tLP));
    }

    private IEnumerator PointMoveUP(Vector3 tLP)
    {
        while (Vect.LowEqual(transform.localPosition, 0))
        {
            tLP.x += Time.deltaTime * _openingCoeff;
            tLP.y += Time.deltaTime * _openingCoeff;

            transform.localPosition = tLP;
            yield return null;
        }
    }
    private IEnumerator PointMoveDown(Vector3 tLP)
    {
        while (Vect.HighEqual(transform.localPosition, 0))
        {
            tLP.x -= Time.deltaTime * _openingCoeff;
            tLP.y -= Time.deltaTime * _openingCoeff;

            transform.localPosition = tLP;
            yield return null;
        }
    }


}
