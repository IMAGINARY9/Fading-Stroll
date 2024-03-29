﻿using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerUpgrade : MonoCache
{
    [SerializeField] private DataHolder _playerData;
    [SerializeField] private UI _ui;
    [SerializeField] private int _lastStagePrice;
    [SerializeField] private int _maxPrice;
    [SerializeField] private int _sliderPrice;
    private int _price;

    private void Start()
    {
        _playerData.LevelChanged += UpdateLevel;
        _playerData.ScoreChanged += UpdatePrice;
        UpdateLevel();
        _ui.UpdateGuide(_playerData.Level == 1);
    }

    public void Upgrade()
    {
        _ui.UpdateButtonColor(EnoughFunds);
        if(EnoughFunds)
        {
            FundsUpdate();
            UpgradeLevel();
        }
    }

    private void UpdateSize() => _ui.UpdateButtonSize(100 * _playerData.Level + 200);
    private bool EnoughFunds => _playerData.Score >= _price;
    private void FundsUpdate() => _playerData.Score -= _price;
    private void UpdatePrice()
    {
        int price = Mathf.CeilToInt(63.5962f * Mathf.Pow(_playerData.Level + 0.1f, 4.1182f));
        bool defaultPrice = price <= _maxPrice;
        if (defaultPrice)
        {
            _price = price <= _lastStagePrice ? price : _maxPrice;
            _ui.UpdatePriceText(_playerData.Score + "/" + _price);
        }
        else
        {
            _price = int.MaxValue;
            _ui.UpdatePriceText(_playerData.Score + "/max");
        }
        _ui.CanResetProgress = !defaultPrice;
        _ui.UpdateResetProgressButton();

        _ui.SliderUnlock = _playerData.Score >= _sliderPrice;
        _ui.UpdateLevelSlider();

        _ui.UpdateTapText(EnoughFunds);
        UpdateScore();
    }

    public void UpdateLevel()
    {
        _ui.UpdateLevelIndicator(_playerData.Level);
        UpdatePrice();
        UpdateSize();
    }
    private void UpgradeLevel() => _playerData.Level += 0.1f;
    private void UpdateScore() => _ui.UpdateScoreIndicator(_playerData.Score);

    private void OnDisable()
    {
        PlayerInfo.PlayerDestroy -= UpdatePrice;
        _playerData.LevelChanged -= UpdateLevel;
        _playerData.ScoreChanged -= UpdatePrice;
    }
}
