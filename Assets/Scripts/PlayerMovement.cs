using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask magneticLayer;
    public float speed = 5f;
    public float jumpingPower = 8f;

    //private Animator animator;

    [SerializeField] private AudioSource jumpSoundEffect;

    private float horizontal;
    private bool isFacingRight = true;

    //private enum MovementState { idle, running, jumping, falling }
    //private MovementState state;


    // Start is called before the first frame update
    void Start()
    {
        // sprite = GetComponent<RigidBody2D>();

        // animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0.1f)
        {
            Flip();
            // sprite.flipX = false;
        }
        else if (isFacingRight && horizontal < -0.1f)
        {
            Flip();
            // sprite.flipX = true;
        }

        if (horizontal != 0f)
        {
            // state = MovementState.running;
        }
        else
        {
            // state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            // state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            // state = MovementState.falling;
        }

        // animator.SetInteger("state", (int)state);

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            FindObjectOfType<audioManager>().Play("Player Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

    private bool IsGrounded()
    {
        return (Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, 0.2f, magneticLayer));
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;

    }

}
