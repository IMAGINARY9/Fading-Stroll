using System.Collections;
using UnityEngine;

public class SoundSwitch : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private DataHolder _dataHolder;
    [SerializeField] private GameObject[] _indicators;

    private void Awake()
    {
        _sound.mute = _dataHolder.Mute;
        if (_sound.mute) ReactivateIcons();
    }
    public void Switch()
    {
        _sound.mute = !_sound.mute;
        _dataHolder.Mute = _sound.mute;
        ReactivateIcons();
    }

    private void ReactivateIcons()
    {
        foreach (var ind in _indicators)
            ind.SetActive(!ind.activeSelf);
    }
}
