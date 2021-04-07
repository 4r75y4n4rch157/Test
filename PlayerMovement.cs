using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponant(typeof(PlayerPhysics))]

public class PlayerMovement : MonoBehaviour
{//Player Control
    public float gravity = 21;
    public float speed = 9;
    public float velocity = 27;
    public float jumpVelocity = 13;

    private float actualSpeed;
    private float potentialSpeed;
    private Vector2 howFar;
    private PlayerPhysics playerPhysics;

    // Start is called before the first frame update
    void Start()
    {
        playerPhysics = GetComponant<PlayerPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        potentialSpeed = Input.GetAxisRaw("Horizontal") * speed;
        actualSpeed = IncrementalSpeed(actualSpeed, potentialSpeed, velocity)

        if(playerPhysics.grounded)
        {
            howFar.y = 0;

            if (Input.getButtonDown("Jump"))
            {
                howFar.y = jumpVelocity;
            }
        }

        howFar.x = actualSpeed;
        howFar.y -= gravity * Time.deltaTime;
        playerPhysics.Move(howFar * Time.deltaTime)
    }

    //Increment toward potential
    private float IncrementalSpeed(float A, float potential, float V){
        if (A == potential) {
            return A;
        }
        else {
            float dir = Mathf.Sign(potential - A); //checking to see if we increase or decrease speed to meet potential.
            A += V * Time.deltaTime * dir;
            return(dir == Mathf.Sign(potential - A))? A: potential; 
        }
    }
}
