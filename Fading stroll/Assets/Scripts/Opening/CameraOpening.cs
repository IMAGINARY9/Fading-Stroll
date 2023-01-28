using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraOpening : MonoCache
{
    [SerializeField] private float _openingSpeed;
    [SerializeField] private DataHolder _dataHolder;
    private CinemachineVirtualCamera _vcam;
    public float OpeningSpeed { get => _openingSpeed; set => _openingSpeed = value; }

    void Start()
    {
        _vcam = GetComponent<CinemachineVirtualCamera>();
        StartCoroutine(CameraRoutine(_dataHolder.Level + 10));
    }
    IEnumerator CameraRoutine(float orthographicSize)
    {
        while (_vcam.m_Lens.OrthographicSize < orthographicSize)
        {
            _vcam.m_Lens.OrthographicSize += OpeningSpeed * Time.deltaTime;
            yield return null;
        }
    }

}
