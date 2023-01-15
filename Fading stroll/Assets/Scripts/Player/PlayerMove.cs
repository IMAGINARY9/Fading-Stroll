using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : InteractiveBody
{
    [SerializeField] private float _acceleration;
    [SerializeField] private float _decceleration;
    [SerializeField] private float _velPower;
    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;

    private Vector2 _dir;
    public Vector2 Path => rb.velocity.normalized;
    public override void OnFixedTick()
    {

#if UNITY_ANDROID
        _dir.x = _joystick.Horizontal;
        _dir.y = _joystick.Vertical;
#else
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.y = Input.GetAxisRaw("Vertical");
#endif
        Move();
    }

    private void Move()
    {
        Vector2 targetSpeed = _dir.normalized * _speed;
        Vector2 speedDif = targetSpeed - rb.velocity;
        float accelRate = Vect.Low(Vect.Abs(targetSpeed), 0.01f) ? _decceleration : _acceleration;
        Vector2 movement = Vect.Pow(Vect.Abs(speedDif) * accelRate, _velPower) * Vect.Sign(speedDif);

        rb.AddForce(movement, ForceMode2D.Force);
    }
    private void OnEnable() => AddFixedUpdate();
    private void OnDisable() => RemoveFixedUpdate();

    public static Action PlayerDestroy;
    private void OnDestroy()
    {
        PlayerDestroy?.Invoke();
        RemoveFixedUpdate();
    }

}
