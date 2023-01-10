using System.Collections;
using UnityEngine;

public static class Vect
{
    
    public static Vector2 RandomVector =>
        new(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    public static Vector2 RandomSimilarVector(){
        var rNum = Random.Range(-1f, 1f);
        return new(rNum, rNum);
    }
    public static bool Low(Vector2 vector, float value) =>
        vector.x < value && vector.y < value;
    public static bool LowEqual(Vector2 vector, float number) =>
        vector.x <= number && vector.y <= number;
    public static Vector2 RandVector(Vector2 min, Vector2 max) =>
        new(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
    public static Vector3 RandVector(float min, float max) =>
        new(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
    public static Vector2 Abs(Vector2 vector) =>
        new(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
    public static Vector2 Sign(Vector2 vector) =>
        new(Mathf.Sign(vector.x), Mathf.Sign(vector.y));
    public static Vector2 Pow(Vector2 vector, float value) =>
        new(Mathf.Pow(vector.x, value), Mathf.Pow(vector.y, value));
}
