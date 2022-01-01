using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private Inventory_UI uiInventory;
    private Inventory inventory;
    private PauseMenu pm;
    private void Start()
    {
        
    }

    // Variables for basic movement
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private KeyCode lastKey;


    // Variables for mouse inputs
    Vector2 mousePos;
    public Camera cam;

    // Variables for dashing cooldown timer
    public bool dashCooldown = false;
    public float dashCooldownTime = 10.0f;
    public float dashCooldownTimer = 0.0f;
    
    
    void Update()
    {
        pm = FindObjectOfType<PauseMenu>();
        if (!pm.gameIsPaused)
        {
            // calling processInputs method
            ProcessInputs();
        }
    }

    void FixedUpdate()
    {

        // Physics processing
        Move();

    }

    void ProcessInputs()
    {
        // ------------------BASIC DIRECTIONAL MOVEMENT-----------------

        // Getting directional inputs from player
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Checking if player's last key was: W, A, S or D
        if (Input.GetKeyDown(KeyCode.W)) lastKey = KeyCode.W;

        if (Input.GetKeyDown(KeyCode.A)) lastKey = KeyCode.A;

        if (Input.GetKeyDown(KeyCode.S)) lastKey = KeyCode.S;

        if (Input.GetKeyDown(KeyCode.D)) lastKey = KeyCode.D;





        // ------------------------MOUSE INPUT--------------------------

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);




        // ----------------DASH MOVEMENT WITH CD TIMER------------------


        // If player presses Left Shift
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {   

            if (!dashCooldown)
            {
                // Checks what the player's last directional key was and sets dash respectively
                if (lastKey == KeyCode.W) transform.position += new Vector3(moveX, 5);

                else if (lastKey == KeyCode.A) transform.position += new Vector3(-5, moveY);

                else if (lastKey == KeyCode.S) transform.position += new Vector3(moveX, -5);

                else if (lastKey == KeyCode.D) transform.position += new Vector3(5, moveY);

                dashCooldownTimer = dashCooldownTime;
                dashCooldown = true;
            }
        }

        dashCooldownTimer -= Time.deltaTime;
        if (dashCooldownTimer <= 0.0f)
        {
            dashCooldown = false;
        }

    }

    void Move()
    {
        // Multiplyed by Time.deltatime and movespeed to control the consistency and the speed the sprite walks at
        rb.velocity = new Vector2(moveDirection.x * moveSpeed * Time.deltaTime, moveDirection.y * moveSpeed * Time.deltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
