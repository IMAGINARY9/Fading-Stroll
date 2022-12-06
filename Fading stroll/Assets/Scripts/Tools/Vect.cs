using System.Collections;
using UnityEngine;

public static class Vect
{
    public static bool Low(Vector2 vector, float value) =>
        vector.x < value && vector.y < value;
    public static Vector2 Abs(Vector2 vector) =>
        new(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
    public static Vector2 Sign(Vector2 vector) =>
        new(Mathf.Sign(vector.x), Mathf.Sign(vector.y));
    public static Vector2 Pow(Vector2 vector, float value) =>
        new(Mathf.Pow(vector.x, value), Mathf.Pow(vector.y, value));
}
