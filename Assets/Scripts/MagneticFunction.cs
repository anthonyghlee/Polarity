using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagneticFunction : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float magStrengthVert = 60f;
    [SerializeField] float magStrengthHoriz = 100f;
    [SerializeField] float castDistance = 7f;
    
    public float horizmagdir;
    public float vertmagdir;

    bool isGrounded = false;
    bool isRepel = false;
    bool isUpArrow = false;
    bool isDownArrow = false;
    bool isRightArrow = false;
    bool isLeftArrow = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    MagnetUp(); 
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    MagnetDown(); 
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    MagnetRight(); 
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //   MagnetLeft(); 
        //}
        int magneticLayerMask = LayerMask.GetMask("Magnetic");

        RaycastHit2D raycastHitUp = Physics2D.Raycast (transform.position, Vector2.up, castDistance, magneticLayerMask);
        RaycastHit2D raycastHitDown = Physics2D.Raycast (transform.position, Vector2.down, castDistance, magneticLayerMask);
        RaycastHit2D raycastHitRight = Physics2D.Raycast (transform.position, Vector2.right, castDistance, magneticLayerMask);
        RaycastHit2D raycastHitLeft = Physics2D.Raycast (transform.position, Vector2.left, castDistance, magneticLayerMask);

        if (raycastHitUp.collider != null && raycastHitUp.rigidbody != null)
        {
            Rigidbody2D hitRbUp = raycastHitUp.rigidbody.GetComponent<Rigidbody2D>();

            if(isUpArrow == true && isGrounded == false)
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
            else if(isUpArrow == true && isGrounded == true)
            {
                if(isRepel == false)
                {
                    hitRbUp.AddForce(Vector2.down * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    hitRbUp.AddForce(Vector2.down * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
        }

        if (raycastHitDown.collider != null && raycastHitDown.rigidbody != null)
        {
            Rigidbody2D hitRbDown = raycastHitDown.rigidbody.GetComponent<Rigidbody2D>();

            if(isDownArrow == true && isGrounded == false)
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
            else if(isDownArrow == true && isGrounded == true)
            {
                if(isRepel == false)
                {
                    hitRbDown.AddForce(Vector2.up * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    hitRbDown.AddForce(Vector2.up * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
        }

        if (raycastHitRight.collider != null && raycastHitRight.rigidbody != null)
        {
            Rigidbody2D hitRbRight = raycastHitRight.rigidbody.GetComponent<Rigidbody2D>();

            if(isRightArrow == true && isGrounded == false)
            {
                if(isRepel == false)
                {
                    rb.AddForce(Vector2.right * magStrengthHoriz, ForceMode2D.Force);
                }
                else
                {
                    rb.AddForce(Vector2.right * magStrengthHoriz * -1f, ForceMode2D.Force);
                }
            }
            else if(isRightArrow == true && isGrounded == true)
            {
                if(isRepel == false)
                {
                    hitRbRight.AddForce(Vector2.left * magStrengthHoriz, ForceMode2D.Force);
                }
                else
                {
                    hitRbRight.AddForce(Vector2.left * magStrengthHoriz * -1f, ForceMode2D.Force);
                }
            }
        }

        if (raycastHitLeft.collider != null && raycastHitLeft.rigidbody != null)
        {
            Rigidbody2D hitRbLeft = raycastHitLeft.rigidbody.GetComponent<Rigidbody2D>();

            if(isLeftArrow == true && isGrounded == false)
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
            else if(isLeftArrow == true && isGrounded == true)
            {
                if(isRepel == false)
                {
                    hitRbLeft.AddForce(Vector2.right * magStrengthHoriz, ForceMode2D.Force);
                }
                else
                {
                    hitRbLeft.AddForce(Vector2.right * magStrengthHoriz * -1f, ForceMode2D.Force);
                }
            }
        }
    }

    void Magnet(InputAction.CallbackContext context)
    {
        horizmagdir = context.ReadValue<Vector2>().x;
        vertmagdir = context.ReadValue<Vector2>().y;

        Debug.Log("Input");

        if (context.performed)
        {
            if (horizmagdir == 1f)
            {
                isRightArrow = true;
                Debug.Log("Right");
                FindObjectOfType<audioManager>().Play("Magnet Sound");
            }
            else if (horizmagdir == -1f)
            {
                isLeftArrow = true;
                Debug.Log("Left");
                FindObjectOfType<audioManager>().Play("Magnet Sound");
            }
            else if (vertmagdir == 1f)
            {
                isUpArrow = true;
                Debug.Log("Up");
                FindObjectOfType<audioManager>().Play("Magnet Sound");
            }
            else if (vertmagdir == -1f)
            {
                isDownArrow = true;
                Debug.Log("Down");
                FindObjectOfType<audioManager>().Play("Magnet Sound");
            }
        }
        else if (context.canceled)
        {
            isRightArrow = false;
            isLeftArrow = false;
            isUpArrow = false;
            isDownArrow = false;
            FindObjectOfType<audioManager>().Stop("Magnet Sound");
        }
    }
        public void ToggleRepel(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            isRepel = !isRepel;
        }
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
}


//issues:
//player still able to run around while the magnet is in place
//when attracting objects, the player slides around a little too