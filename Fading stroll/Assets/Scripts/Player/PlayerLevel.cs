using UnityEngine;

[CreateAssetMenu(fileName = "PlayerLevel", menuName = "PlayerLevel", order = 0)]
public class PlayerLevel : ScriptableObject
{
    public float Level { get; set; }
}
