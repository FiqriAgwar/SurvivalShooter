using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : Command
{
    PlayerShooting shooting;
    public ShootCommand(PlayerShooting _shooting){
        shooting = _shooting;
    }

    public override void Execute(){
        shooting.Shoot();
    }

    public override void Unexecute(){
        
    }
}
