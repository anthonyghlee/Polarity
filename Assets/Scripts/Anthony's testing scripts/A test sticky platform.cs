using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aTestStickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collision.gameObject.name == "Player")
        {
            playerRb.gravityScale = 2f;

            collision.gameObject.transform.SetParent(null);
        }
    }
}
