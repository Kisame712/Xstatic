using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance;
    private Rigidbody playerRb;
    private Animator playerAnim;
    Vector2 playerInput;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        if (playerInput != Vector2.zero)
        {
            playerAnim.SetBool("isRunning", true);
        }
        else
        {
            playerAnim.SetBool("isRunning", false);
        }
        playerRb.linearVelocity += new Vector3(playerInput.x, 0f, playerInput.y) * moveSpeed * Time.fixedDeltaTime;
    }

    private void Jump()
    {
        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {
            playerAnim.SetTrigger("jump");
            playerRb.linearVelocity += new Vector3(0f, 1f, 0f) * jumpSpeed * Time.fixedDeltaTime; 
        }
    }

    private bool IsGrounded()
    {
        if(Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundLayer))
        {
            return true;
        }
        return false;
    }
}
