using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRB;

    public float maxSpeed;

    public float accelerationTime;
    private float acceleration;

    public float deceleration;

    public LayerMask groundLayer;
    public Transform check;


    public float terminalSpeed;

    public float coyoteTime = 0.3f;
    private float timer = 0f;


    Vector3 currentVelocity;

    public enum FacingDirection
    {
        left, right
    }

    FacingDirection nowfd = FacingDirection.right;

    public float apexHeight;
    public float apexTime;



    float gravity;
    float initialJumpVelocity;
    bool wasJumpTriggered = false;


    // Start is called before the first frame update
    void Start()
    {
        //move
        acceleration = maxSpeed / accelerationTime;
        //jump
        gravity = -2 * apexHeight / (apexTime * apexTime);
        initialJumpVelocity = 2 * apexHeight / apexTime;
    }


    void FixedUpdate()
    {
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
        Vector2 playerInput = new Vector2();
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput.x += 1f;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput.x -= 1f;
        }
        MovementUpdate(playerInput);
    }


    // Update is called once per frame
    void Update()
    {

        //if the player provide input for a jump, give them the initial
        if (IsGrounded())
        {
            timer = coyoteTime;
        }
        else{
            timer -= Time.deltaTime;
        }

        if(Keyboard.current.upArrowKey.wasPressedThisFrame && timer > 0f)
        {
                wasJumpTriggered = true;
                timer = 0f;
        }
    }

    private void MovementUpdate(Vector2 playerInput)
    {

        //jump
        Vector2 currentVelocity = playerRB.linearVelocity;

        //apply the gravity that we calculate over time
        currentVelocity.y += gravity * Time.deltaTime;


        if (wasJumpTriggered)
        {
            currentVelocity.y = initialJumpVelocity;
            timer = 0f;
            wasJumpTriggered = false;
        }

        if (currentVelocity.y < -terminalSpeed)
        {
            currentVelocity.y = -terminalSpeed;
        }

        playerRB.linearVelocity = currentVelocity;

        //move
        Vector2 newVelocity = playerRB.linearVelocity;

        if (playerInput.x != 0)
        {
            //accelerate
            newVelocity += playerInput * acceleration * Time.deltaTime;
        }
        else
        {
            newVelocity.x = Mathf.MoveTowards(newVelocity.x, 0f, deceleration * Time.deltaTime);
        }

        if (newVelocity.x > maxSpeed )
        {
            newVelocity.x = maxSpeed;
        }
        if (newVelocity.x < -maxSpeed )
        {
            newVelocity.x = -maxSpeed;
        }

        playerRB.linearVelocity = newVelocity;


       
    }


    public bool IsWalking()
    {

        if (playerRB.linearVelocity.x > 0.01f || playerRB.linearVelocity.x < -0.01f)
        {
            return true;
        }
        
        return false;
    }
    public bool IsGrounded()
    {
        RaycastHit2D c = Physics2D.Raycast(check.position, Vector2.down, 0.3f, groundLayer);
        if (c.collider != null)
        {
            return true;
        }

        return false;
    }

    public FacingDirection GetFacingDirection()
    {

        if (playerRB.linearVelocity.x > 0.01f)
        {
            nowfd = FacingDirection.right;
        }

        if (playerRB.linearVelocity.x < -0.01f)
        {
            nowfd = FacingDirection.left;
        }

        return nowfd;
    }
}

