using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    PlayerMovement movement;
    float x,z;

    public MoveCommand(PlayerMovement _movement, float _x, float _z){
        this.movement = _movement;
        this.x = _x;
        this.z = _z;
    }

    public override void Execute(){
        movement.Move(x,z);
        movement.Animating(x,z);
    }

    public override void Unexecute(){
        movement.Move(-x, -z);
        movement.Animating(x,z);
    }
}
