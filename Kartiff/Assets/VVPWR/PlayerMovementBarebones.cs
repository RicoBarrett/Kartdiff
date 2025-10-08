using UnityEngine;

public class PlayerMovementBarebones : MonoBehaviour
{
    [Header("movement settings")]
    public float moveSpeed = 6f; // how fast player moves
    public float groundDrag = 5f; // how much drag when grounded

    [Header("ground check settings")]
    public float playerHeight = 2f; // used to check if grounded
    public LayerMask whatIsGround; // tells which layer is ground
    public Transform orientation; // used to move relative to camera/player facing

    private Rigidbody rb;
    private bool grounded;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // stops player from falling over
    }

    void Update()
    {
        // check if touching ground using a raycast
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        GetInput();
        HandleDrag();
        LimitSpeed();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void GetInput()
    {
        // simple movement input (WASD or arrows)
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        // moves based on player facing direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    void HandleDrag()
    {
        // only apply drag if grounded (so we don't slide forever)
        rb.drag = grounded ? groundDrag : 0f;
    }

    void LimitSpeed()
    {
        // makes sure player doesn't go faster than intended
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

}

//script inspired by youtube tutorial and edited to match our games needs
//https://www.youtube.com/watch?v=f473C43s8nE