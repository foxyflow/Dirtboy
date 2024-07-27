using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AgentData", menuName = "Agent/Data")]
public class AgentDataSO : ScriptableObject
{
    [Header("Movement data")]
    [Space]
    public float maxSpeed = 6;
    public float acceleration = 50;
    public float deceleration = 50;

    [Header("Jump data")]
    [Space]
    public float jumpForce = 12;
    public float lowJumpMultiplier = 2; //to control gravity/falling. EG * twice the gravity
    public float gravityModifier = 0.5f;

    [Header("Climb data")]
    [Space]
    public float climbHorizontalSpeed = 2;
    public float climbVerticalSpeed = 5;
}
