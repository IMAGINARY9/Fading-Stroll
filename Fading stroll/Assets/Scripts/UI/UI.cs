﻿using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("OnReset")]
    [SerializeField] private GameObject _center;
    [SerializeField] private GameObject _resetProgressButton;
    [SerializeField] private GameObject _levelSlider;
    [SerializeField] private GameObject _scoreText;
    [SerializeField] private GameObject _joystic;
    [SerializeField] private GameObject _soundButton;

    [Header("OnUpdate")]
    [SerializeField] private RectTransform _button;
    [SerializeField] private Image _buttonBorder;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private TextMeshProUGUI _scoreIndicator;
    [SerializeField] private GameObject _tapText;
    [SerializeField] private GameObject _moveButton;
    [SerializeField] private TextMeshProUGUI _moveText;
    [SerializeField] private GameObject _guide;

    private void Start()
    {
        PlayerInfo.PlayerDestroy += OnPlayerDestroy;
        _resetProgressButton.SetActive(false);
        IsGame = true;
    }
    public bool CanResetProgress { get; set; }
    public bool SliderUnlock { get; set; }
    static public bool IsGame { get; private set; }
    private void OnPlayerDestroy()
    {
        IsGame = false;
        _resetProgressButton.SetActive(CanResetProgress);
        _levelSlider.SetActive(SliderUnlock);
        
        _center.SetActive(true);
        _soundButton.SetActive(true);

        _guide.SetActive(false);
        _scoreText.SetActive(false);
        _joystic.SetActive(false);
        _moveButton.SetActive(false);
        PlayerInfo.PlayerDestroy -= OnPlayerDestroy;
    }
    public void UpdateButtonSize(float size) => _button.sizeDelta = new Vector2(size, size);
    public void UpdateLevelIndicator(float level) => _levelText.SetText(level.ToString().Replace(',', '.'));
    public void UpdateScoreIndicator(float score) => _scoreIndicator.SetText(score.ToString());
    public void UpdateResetProgressButton() => _resetProgressButton.SetActive(!IsGame && CanResetProgress);
    public void UpdateLevelSlider() => _levelSlider.SetActive(!IsGame && SliderUnlock);
    public void UpdateTapText(bool s) => _tapText.SetActive(s);
    public void UpdateGuide(bool s) => _guide.SetActive(s);
    public void UpdateMoveButton(bool s)
    {
        _moveButton.SetActive(IsGame && s);
        if(_moveButton.activeSelf)
            _guide.SetActive(false);
    }
    public void UpdateMoveText(float size) => _moveText.fontSize = size <= 650f ? size : 650f;
    public void UpdatePriceText(string msg) => _priceText.SetText(msg);
    public void UpdateButtonColor(bool s)
    {
        StopAllCoroutines();
        StartCoroutine(ColorRoutine(s));
    }
    IEnumerator ColorRoutine(bool s)
    {
        _buttonBorder.color = s ? Color.green : Color.red;
        yield return new WaitForSeconds(0.1f);
        _buttonBorder.color = Color.white;
    }

}
