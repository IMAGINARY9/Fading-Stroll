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

    [Header("OnUpdate")]
    [SerializeField] private RectTransform _button;
    [SerializeField] private Image _buttonBorder;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private TextMeshProUGUI _scoreIndicator;
    [SerializeField] private GameObject _resetScoreButton;
    [SerializeField] private GameObject _tapText;

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

    public void UpdateButtonSize(float size) => _button.sizeDelta = new Vector2(size, size);
    public void UpdateLevelIndicator(float level) => _levelText.SetText(level.ToString().Replace(',', '.'));
    public void UpdateScoreIndicator(float score) => _scoreIndicator.SetText(score.ToString());
    public void UpdateResetDataButton(bool s) => _resetScoreButton.SetActive(s);
    public void UpdateTapText(bool s) => _tapText.SetActive(s);
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
