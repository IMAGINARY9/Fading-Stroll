using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerUpgrade : MonoCache
{
    [SerializeField] private DataHolder _playerData;
    [SerializeField] private RectTransform _button;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private TextMeshProUGUI _scoreIndicator;

    private int _price;

    private void Start()
    {
        _playerData.LevelChanged += UpdateLevel;
        _playerData.ScoreChanged += UpdatePrice;
        UpdateLevel();
    }

    public void Upgrade()
    {
        if(EnoughFunds)
        {
            FundsUpdate();
            UpgradeLevel();
        }
    }

    private void UpdateSize()
    {
        var newSize = 50 * _playerData.Level + 450;
        _button.sizeDelta = new Vector2(newSize, newSize);
    }
    private bool EnoughFunds => _playerData.Score >= _price;
    private void FundsUpdate() => _playerData.Score -= _price;
    private void UpdatePrice()
    {
        int price = Mathf.CeilToInt(63.5962f * Mathf.Pow(_playerData.Level + 0.1f, 4.1182f));
        _price = price <= 50000 ? price <= 45000 ? price : 50000 : 100000;
        _priceText.SetText(_playerData.Score + "/" + _price);
        UpdateScore();
    }
    public void UpdateLevel()
    {
        _levelText.SetText(_playerData.Level.ToString().Replace(',', '.'));
        UpdatePrice();
        UpdateSize();
    }
    private void UpgradeLevel() => _playerData.Level += 0.1f;
    private void UpdateScore() => _scoreIndicator.SetText(_playerData.Score.ToString());

    private void OnDisable()
    {
        PlayerInfo.PlayerDestroy -= UpdatePrice;
        _playerData.LevelChanged -= UpdateLevel;
        _playerData.ScoreChanged -= UpdatePrice;
    }
}
