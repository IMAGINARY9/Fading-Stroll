﻿using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _resetButton;

    private void Start()
    {
        PlayerMove.PlayerDestroy += Reset;
    }

    private void Reset()
    {
        PlayerMove.PlayerDestroy -= Reset;
        _resetButton.SetActive(true);
    }
}