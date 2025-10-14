using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
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
    }

    void Run()
    {
        playerRb.linearVelocity += new Vector3(playerInput.x, 0f, playerInput.y) * moveSpeed * Time.deltaTime;
    }


}
