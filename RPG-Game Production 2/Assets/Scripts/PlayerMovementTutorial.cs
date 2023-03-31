using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovementTutorial : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float runSpeed;

    public float groundDrag;

    public float jumpForce;
    public float dodgeForce;
    public float jumpCooldown;
    public float hitCooldown;
    public float airMultiplier;
    public bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode interactKey = KeyCode.F;
    public KeyCode drawKey = KeyCode.R;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode attackKey = KeyCode.Mouse0;
    public KeyCode blockKey = KeyCode.Mouse1;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;
    public bool hit;

    public Transform orientation;
    public Animator animator;

    public Collider swordCollider;
    public Collider shieldCollider;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private bool JumpPressed = false;
    private bool IsFalling = false;
    private bool ApproachingGround = false;
    private float blockTimer = 0f;

    [Header("enemy look at")]
    public Transform enemy;
    public Transform body;
    public bool lookingAt;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            hit = true;
            hitCooldown = 3;
        }
        if (collision.gameObject.CompareTag("Mesh"))
        {
            print("Collided with mesh");
        }
    }

    private void Update()
    {
        // ground check
        //grounded = Physics.Raycast(GameObject.FindWithTag("PlayerModel").transform.position, Vector3.down, 0.15f, whatIsGround);
        ApproachingGround = Physics.Raycast(transform.position, Vector3.down, 1f, whatIsGround);
        Debug.DrawRay(transform.position, Vector3.down, Color.cyan);
        //Control animations depending on if grounded
        if (grounded)
        {
            animator.SetBool("IsGrounded", true);
        } else { animator.SetBool("IsGrounded", false); }

        if (Input.GetKeyDown("q"))
        {
            lookingAt = !lookingAt;
        }

        LookAt();
        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        if (hitCooldown >= 0)
        {
            hitCooldown -= Time.deltaTime;
        }
        else
        {
            hit = false;
        }

        if (Input.GetKey(runKey))
        {
            sprintSpeed = runSpeed;
            animator.SetBool("IsRunning", true);
        } else 
        {
            sprintSpeed = 1f;
            animator.SetBool("IsRunning", false);
        }

        //Change animation based on input
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")/* || Input.GetButton("W")*/)
        {
            animator.SetBool("IsMoving", true);
        }
        else { animator.SetBool("IsMoving", false); }

        if (JumpPressed)
        {
            animator.SetBool("JumpPressed", true);
        } else { animator.SetBool("JumpPressed", false); }

        if(rb.velocity.y <= -0.01f)
        {
            IsFalling = true;
        } else { IsFalling = false; }

        if (IsFalling)
        {
            animator.SetBool("IsFalling", true);
        }
        else { animator.SetBool("IsFalling", false); }

        if (ApproachingGround)
        {
            animator.SetBool("ApproachingGround", true);
        }
        else { animator.SetBool("ApproachingGround", false); }

        
        if (grounded)
        {
            if (Input.GetKey(blockKey))
            {
                blockTimer += Time.deltaTime;
                Block();
                if (blockTimer >= 0.1f)
                {
                    animator.SetBool("BlockPressed", false);
                }
            }
            else
            {
                blockTimer = 0f;
                animator.SetBool("BlockPressed", false);
                animator.SetBool("IsBlocking", false);
                shieldCollider.enabled = false;
            }
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        if (hit == false)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }
        if (hit == true)
        {
            horizontalInput = Input.GetAxisRaw("Anti Horizontal");
            verticalInput = Input.GetAxisRaw("Anti Vertical");
        }

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        else { JumpPressed = false; }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(transform.forward * dodgeForce * -1, ForceMode.Impulse);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * sprintSpeed, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier * sprintSpeed, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        JumpPressed = true;
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    private void LookAt()
    {
        if(lookingAt == true)
        {
            transform.LookAt(enemy.transform.position);
        }
        else
        {

        }
    }

    private void Attack()
    {
        swordCollider.enabled = true;
        animator.SetBool("Attacking", true);
    }

    private void Block()
    {
        shieldCollider.enabled = true;
        animator.SetBool("IsBlocking", true);
        animator.SetBool("BlockPressed", true);
        animator.SetLayerWeight(1, 0.7f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            grounded = false;
        }
    }
}