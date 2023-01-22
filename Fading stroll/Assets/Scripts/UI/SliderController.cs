using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private DataHolder _playerLevel;
    private void Awake() => UpdateSlider();
    private void Start() => _playerLevel.LevelChanged += UpdateSlider;
    private void UpdateSlider() => _slider.value = _playerLevel.Level * 10;
    public void UpdateLevel() => _playerLevel.Level = _slider.value * 0.1f;
    private void OnDisable() => _playerLevel.LevelChanged -= UpdateSlider;
}
