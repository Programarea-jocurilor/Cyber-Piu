using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 1.1f;
    
    public float minAgroDistance = 4f;  
    public float maxAgroDistance = 6f;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
