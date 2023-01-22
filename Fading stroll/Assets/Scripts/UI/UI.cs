using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _center;
    [SerializeField] private GameObject _resetProgressButton;
    [SerializeField] private GameObject _levelSlider;

    private void Start() => PlayerInfo.PlayerDestroy += Reset;

    private void Reset()
    {
        PlayerInfo.PlayerDestroy -= Reset;
        _center.SetActive(true);
        _resetProgressButton.SetActive(true);
        _levelSlider.SetActive(true);
    }
}
