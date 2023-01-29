using System.Collections;
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

    private void Start()
    {
        PlayerInfo.PlayerDestroy += OnPlayerDestroy;
        _resetProgressButton.SetActive(false);
        _isGame = true;
    }

    public bool CanResetProgress { get; set; }
    private bool _isGame;
    private void OnPlayerDestroy()
    {
        _isGame = false;
        _resetProgressButton.SetActive(CanResetProgress);
        
        _center.SetActive(true);
        _levelSlider.SetActive(true);
        _soundButton.SetActive(true);

        _scoreText.SetActive(false);
        _joystic.SetActive(false);
        _moveButton.SetActive(false);
        PlayerInfo.PlayerDestroy -= OnPlayerDestroy;
    }
    public void UpdateButtonSize(float size) => _button.sizeDelta = new Vector2(size, size);
    public void UpdateLevelIndicator(float level) => _levelText.SetText(level.ToString().Replace(',', '.'));
    public void UpdateScoreIndicator(float score) => _scoreIndicator.SetText(score.ToString());
    public void UpdateResetProgressButton() => _resetProgressButton.SetActive(!_isGame && CanResetProgress);
    public void UpdateTapText(bool s) => _tapText.SetActive(s);
    public void UpdateMoveButton(bool s) => _moveButton.SetActive(_isGame && s);
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
