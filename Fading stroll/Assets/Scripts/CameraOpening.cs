using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraOpening : MonoCache
{
    [SerializeField] private float _orthographicSize;
    [SerializeField] private float _openingSpeed;
    private CinemachineVirtualCamera _vcam;

    void Start()
    {
        _vcam = GetComponent<CinemachineVirtualCamera>();
        StartCoroutine(CameraRoutine());
    }
    IEnumerator CameraRoutine()
    {
        while (_vcam.m_Lens.OrthographicSize < _orthographicSize)
        {
            _vcam.m_Lens.OrthographicSize += _openingSpeed * Time.deltaTime;
            yield return null;
        }
    }

}
