using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _center;
    [SerializeField] private GameObject _resetProgressButton;
    [SerializeField] private GameObject _levelSlider;
    [SerializeField] private GameObject _scoreText;
    [SerializeField] private GameObject _joystic;

    private void Start() => PlayerInfo.PlayerDestroy += Reset;

    private void Reset()
    {
        PlayerInfo.PlayerDestroy -= Reset;
        _center.SetActive(true);
        _resetProgressButton.SetActive(true);
        _levelSlider.SetActive(true);
        _scoreText.SetActive(false);
        _joystic.SetActive(false);
    }
}
