using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newWallJumpStateData", menuName = "Data/State Data/Wall Jump State")]
public class D_WallJumpState : ScriptableObject
{
    public float wallJumpSpeed = 30f;
    public Vector2 wallJumpAngle;
}
