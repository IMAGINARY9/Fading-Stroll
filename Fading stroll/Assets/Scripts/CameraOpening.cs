using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraOpening : MonoCache
{
    [SerializeField] private float _orthographicSize;
    [SerializeField] private float _openingSpeed;
    private CinemachineVirtualCamera _vcam;
    public float OpeningSpeed { get => _openingSpeed; set => _openingSpeed = value; }

    void Start()
    {
        _vcam = GetComponent<CinemachineVirtualCamera>();
        StartCoroutine(CameraRoutine());
    }
    IEnumerator CameraRoutine()
    {
        while (_vcam.m_Lens.OrthographicSize < _orthographicSize)
        {
            _vcam.m_Lens.OrthographicSize += OpeningSpeed * Time.deltaTime;
            yield return null;
        }
    }

}
