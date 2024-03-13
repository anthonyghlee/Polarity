using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Component references
    // TODO: create variable to store rigidbody of player (2D)
    Rigidbody2D rb;
    // TODO: create variable storing the Animator
    Animator anim;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float magStrengthVert = 1f;
    [SerializeField] float magStrengthHoriz = 5f;
    [SerializeField] float castDistance = 5f;

    //TODO: keep track of current horizontal movement direction
    float direction = 0f;

    //keep track of if the player is on the ground
    bool isGrounded = false;

    //TODO: keep track of which direction player is facing
    bool isFacingRight = true;

    bool isRepel = false;
    bool isHitUp = false;
    bool isHitDown = false;
    bool isHitRight = false;
    bool isHitLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Get references to the rigidbody and animator attached to the current GameObject
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Pass in the proper direction that the player should move in
        Move(direction);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MagnetUp(); 
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            MagnetDown(); 
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MagnetRight(); 
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MagnetLeft(); 
        }

        //while((isHitUp == true) || (isHitDown == true) || (isHitRight == true) || (isHitLeft == true))
        //{
        //    speed = 0f;ss
        //}

        // TODO: check conditions needed to flip player, and if so, flip player
        if((isFacingRight && direction == -1) || (!isFacingRight && direction == 1))
        {
            Flip();
        }
    }

    private void MagnetUp()
    {
        int magneticLayerMask = LayerMask.GetMask("Magnetic");

        RaycastHit2D raycastHit = Physics2D.Raycast (transform.position, Vector2.up, castDistance, magneticLayerMask);

        Rigidbody2D hitRb = raycastHit.rigidbody.GetComponent<Rigidbody2D>();

        if (raycastHit.collider != null)
        {
            isHitUp = true;
        }
        else
        {
            isHitUp = false;
        }

        if(isHitUp == true)
        {
            if (isGrounded == false)
            {
                if(isRepel == false)
                {
                    rb.AddForce(Vector2.up * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    rb.AddForce(Vector2.up * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
            else
            {
                if(isRepel == false)
                {
                    hitRb.AddForce(Vector2.down * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    hitRb.AddForce(Vector2.down * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
        }
    }

    private void MagnetDown()
    {
        int magneticLayerMask = LayerMask.GetMask("Magnetic");

        RaycastHit2D raycastHit = Physics2D.Raycast (transform.position, Vector2.down, castDistance, magneticLayerMask);

        Rigidbody2D hitRb = raycastHit.rigidbody.GetComponent<Rigidbody2D>();

        if (raycastHit.collider != null)
        {
            isHitDown = true;
        }
        else
        {
            isHitDown = false;
        }

        if(isHitDown == true)
        {
            if (isGrounded == false)
            {
                if(isRepel == false)
                {
                    rb.AddForce(Vector2.down * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    rb.AddForce(Vector2.down * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
            else
            {
                if(isRepel == false)
                {
                    hitRb.AddForce(Vector2.up * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    hitRb.AddForce(Vector2.up * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
        }
    }

    private void MagnetRight()
    {
        int magneticLayerMask = LayerMask.GetMask("Magnetic");

        RaycastHit2D raycastHit = Physics2D.Raycast (transform.position, Vector2.right, castDistance, magneticLayerMask);

        Rigidbody2D hitRb = raycastHit.rigidbody.GetComponent<Rigidbody2D>();

        if (raycastHit.collider != null)
        {
            isHitRight = true;
        }
        else
        {
            isHitRight = false;
        }

        if(isHitRight == true)
        {
            if (isGrounded == false)
            {
                if(isRepel == false)
                {
                    Debug.Log("Force added to player");
                    rb.AddForce(Vector2.right * magStrengthHoriz, ForceMode2D.Force);
                }
                else
                {
                    rb.AddForce(Vector2.right * magStrengthHoriz * -1f, ForceMode2D.Force);
                }
            }
            else
            {
                if(isRepel == false)
                {
                    hitRb.AddForce(Vector2.left * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    hitRb.AddForce(Vector2.left * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
        }
    }

    private void MagnetLeft()
    {
        int magneticLayerMask = LayerMask.GetMask("Magnetic");

        RaycastHit2D raycastHit = Physics2D.Raycast (transform.position, Vector2.left, castDistance, magneticLayerMask);

        Rigidbody2D hitRb = raycastHit.rigidbody.GetComponent<Rigidbody2D>();

        if (raycastHit.collider != null)
        {
            isHitLeft = true;
        }
        else
        {
            isHitLeft = false;
        }

        if(isHitLeft == true)
        {
            if (isGrounded == false)
            {
                if(isRepel == false)
                {
                    rb.AddForce(Vector2.left * magStrengthHoriz, ForceMode2D.Force);
                }
                else
                {
                    rb.AddForce(Vector2.left * magStrengthHoriz * -1f, ForceMode2D.Force);
                }
            }
            else
            {
                if(isRepel == false)
                {
                    hitRb.AddForce(Vector2.right * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    hitRb.AddForce(Vector2.right * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
        }
    }

    void OnToggleRepel()
    {
        ToggleRepel();
    }

    private void ToggleRepel()
    {
        if(isRepel == false)
        {
            isRepel = true;
        }
        else
        {
            isRepel = false;
        }
    }

    void OnJump()
    {
        //if player is on the ground, jump
        //if (isGrounded)
        if (isGrounded)
        {    
            Jump();
        }
    }

    private void Jump()
    {
        // TODO: change y velocity of player
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    void OnMove(InputValue moveVal)
    {
        // TODO: store direction input and store it to global variable
        float movDirection = moveVal.Get<float>();
        direction = movDirection;
    }

    private void Move(float x)
    {
        // TODO: change x velocity of player
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        // TODO: Here, we can handle animation transitioning logic
        anim.SetBool("isRunning", x != 0);
    }

    private void Flip()
    {
        // TODO: flip local scale of player and change global variable that stores which direction player is facing
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
        if(collision.gameObject.CompareTag("Magnetic"))
        {
            return;
        }

        List<GameObject> currentCollisions = new List<GameObject>();
        currentCollisions.Add(collision.gameObject);
        Debug.Log(currentCollisions);

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
        {
            Destroy(other.gameObject);
        }
    }
    // TODO: Week 3's assignment needs a couple of extra functions here...


    //public void NextLevel()
    //{
        //nextSceneToLoad = SceneManageer.GetActiveScene().buildIndex + 1;
        //SceneManager.LoadScene(nextSceneToLoad);
    //}

    // if((isHitUp != true) && (isHitDown != true) && (isHitRight != true) && (isHitLeft != true))


}
