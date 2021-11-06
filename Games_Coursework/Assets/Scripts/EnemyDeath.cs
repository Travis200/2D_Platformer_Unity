using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour

{
    Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StompCollider"))
        {
            Destroy(transform.parent.gameObject);
            Rigidbody2D rb = collision.transform.parent.GetComponent<Rigidbody2D>();
            //Set velocity to zero so force from falling does not negate the bounciness of jumping on top of squishable enemy
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }
    }
}
