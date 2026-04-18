using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Movement Settings")]
    public float walkSpeed;
    public float runSpeed;
    public float runStamina;
}
