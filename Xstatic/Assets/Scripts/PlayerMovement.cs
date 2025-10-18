using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform orientation;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance;

    [Header("Attack")]
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackOrigin;
    [SerializeField] private int damageAmount;
    private Rigidbody playerRb;
    private Animator playerAnim;
    Vector2 playerInput;
    Vector3 moveDirection;
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
        LookForward();
        Run();
        Jump();
        Attack();
    }

    private void LookForward()
    {
        // Works if camera is not following the player
        Ray cursorRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (groundPlane.Raycast(cursorRay, out rayLength))
        {
            Vector3 pointToLook = cursorRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

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
 
        moveDirection = orientation.forward * playerInput.y + orientation.right * playerInput.x;
        playerRb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
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

    private void Attack()
    {
        if(IsGrounded() && Input.GetMouseButton(0))
        {
            playerAnim.SetTrigger("attack");
        }
    }

    public void AttackEnemyFromAnimation()
    {
       if(Physics.OverlapSphere(attackOrigin.position, attackRange)!=null)
        {
            Collider[] colliders = Physics.OverlapSphere(attackOrigin.position, attackRange);
            foreach(Collider collider in colliders)
            {
                if(collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    HealthSystem enemyHealthSystem = enemy.GetEnemyHealthSystem();
                    enemyHealthSystem.TakeDamage(damageAmount, false);
                }
            }

        }
    }
}
