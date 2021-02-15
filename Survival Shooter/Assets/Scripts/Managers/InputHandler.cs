using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerShooting shooting;

    Queue<Command> commands = new Queue<Command>();

    void FixedUpdate(){
        Command moveCmd = InputMovementHandling();
        if(moveCmd != null){
            commands.Enqueue(moveCmd);
            moveCmd.Execute();
        }
    }

    void Update(){
        Command shootCmd = InputShootHandling();
        if(shootCmd != null){
            shootCmd.Execute();
        }
    }

    Command InputMovementHandling(){
        if(Input.GetKey(KeyCode.D)){
            return new MoveCommand(movement, 1, 0);
        }
        else if(Input.GetKey(KeyCode.A)){
            return new MoveCommand(movement, -1, 0);
        }
        else if(Input.GetKey(KeyCode.W)){
            return new MoveCommand(movement, 0, 1);
        }
        else if(Input.GetKey(KeyCode.S)){
            return new MoveCommand(movement, 0, -1);
        }
        else if(Input.GetKey(KeyCode.Z)){
            return Undo();
        }
        else{
            return new MoveCommand(movement, 0, 0);
        }
    }

    Command Undo(){
        if(commands.Count > 0){
            Command undoCommand = commands.Dequeue();
            undoCommand.Unexecute();
        }

        return null;
    }

    Command InputShootHandling(){
        if(Input.GetButtonDown("Fire1")){
            return new ShootCommand(shooting);
        }
        else{
            return null;
        }
    }
}
