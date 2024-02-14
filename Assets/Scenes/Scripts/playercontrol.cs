using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontrol : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;

    float direction = 0f;
    bool isGrounded = false;
    bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(direction);
        
        if((isFacingRight && direction == -1) || (!isFacingRight && direction == 1))
            Flip();
    }
    void OnJump()
    {
        if (isGrounded)
            Jump();
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    void OnMove(InputValue moveVal)
    {
        float movDirection = moveVal.Get<float>();
        direction = movDirection;
    }

    private void Move(float x)
    {
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        anim.SetBool("isRunning", x != 0);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 newlocalScale = transform.localScale;
        newlocalScale.x *= -1f;
        transform.localScale = newlocalScale;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        List<GameObject> currentCollisions = new List<GameObject>();
        currentCollisions.Add(collision.gameObject);
        Debug.Log(currentCollisions);
        isGrounded = false;
        for (int i = 0; i < collision.contactCount; i++)
        {
            if (Vector2.Angle(collision.GetContact(i).normal, Vector2.up) < 45f)
            {
                Debug.Log(Vector2.Angle(collision.GetContact(i).normal, Vector2.up));
                isGrounded = true;
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectibles"))
            Destroy(other.gameObject);
    }
}
