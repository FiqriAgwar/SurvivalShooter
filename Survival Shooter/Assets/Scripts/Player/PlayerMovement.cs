using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f; 
    float currentSpeed;

    float boostTime;
    bool boost;

    Vector3 movement;
    Animator animator;
    Rigidbody rb;
    int floorMask;
    float camRayLength = 100f;

    private void Awake(){
        floorMask = LayerMask.GetMask("Floor");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        currentSpeed = speed;
    }

    private void FixedUpdate(){
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        if(boost){
            boostTime -= Time.deltaTime;
            if(boostTime <= 0){
                boost = false;
                currentSpeed = speed;
            }
        }

        Move(x,z);
        Turning();
        Animating(x, z);
    }

    public void Animating(float x, float z){
        bool walking = (x != 0f) || (z != 0f);
        animator.SetBool("IsWalking", walking);
    }

    public void Move(float x, float z){
        movement.Set(x, 0f, z);
        movement = movement.normalized * currentSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    public void Boost(int gain, float time){
        boostTime = time;
        boost = true;

        currentSpeed = speed + gain;
    }

    void Turning(){
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)){
            
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            rb.MoveRotation(newRotation);
        }
    }
}
