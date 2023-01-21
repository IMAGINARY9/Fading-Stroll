using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderNumber;
    [SerializeField] private DataHolder _playerLevel;
    private void Awake()
    {
        _slider.value = _playerLevel.Level * 10;
        UpdateNumber();
    }
    public void UpdateNumber() => _sliderNumber.SetText((_slider.value * 0.1f).ToString().Replace(',','.'));
    public void UpdateLevel() => _playerLevel.Level = _slider.value * 0.1f;

}
