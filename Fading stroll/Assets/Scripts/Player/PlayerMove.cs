using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : InteractiveBody
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private PlayerMoveConfig _config;
    private float Acceleration => _config.Acceleration * Mass;
    private float Decceleration => _config.Decceleration * Mass;
    private float VelPower => _config.VelPower;
    private float Speed => _config.Speed * Mass + 5;


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
        Debug.DrawLine(transform.position, rb.velocity + (Vector2)transform.position, Color.red);
    }

    private void Move()
    {
        Vector2 targetSpeed = _dir.normalized * Speed;
        Vector2 speedDif = targetSpeed - rb.velocity;
        float accelRate = Vect.Low(Vect.Abs(targetSpeed), 0.01f) ? Decceleration : Acceleration;
        Vector2 movement = Vect.Pow(Vect.Abs(speedDif) * accelRate, VelPower) * Vect.Sign(speedDif);

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
