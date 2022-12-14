using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement { get; private set; }
    public CollisionSenses CollisionSenses { get; private set; }
    // public Movement Movement
    // {
    //     get => GenericNotImplementedError<Movement>.TryGet(movement, transform.parent.name);
    //     private set => movement = value;
    // }
    // public CollisionSenses CollisionSenses
    // {
    //     get => GenericNotImplementedError<CollisionSenses>.TryGet(collisionSenses, transform.parent.name);
    //     private set => collisionSenses = value;
    // }
    // public Combat Combat
    // {
    //     get => GenericNotImplementedError<Combat>.TryGet(combat, transform.parent.name);
    //     private set => combat = value;
    // }

    // private Movement movement;
    // private CollisionSenses collisionSenses;
    // private Combat combat;

    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
        // Combat = GetComponentInChildren<Combat>();

        if(!Movement || !CollisionSenses)
        {
            Debug.LogError("Missing Core Component");
        }
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
        // Combat.LogicUpdate();
    }

}