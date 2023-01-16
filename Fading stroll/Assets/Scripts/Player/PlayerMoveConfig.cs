using UnityEngine;


[CreateAssetMenu(fileName = "PlayerMoveConfig", menuName = "PlayerMoveConfig", order = 0)]
public class PlayerMoveConfig : ScriptableObject
{
    [field: SerializeField] public float Acceleration { get; private set; }
    [field: SerializeField] public float Decceleration { get; private set; }
    [field: SerializeField] public float VelPower { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
}
