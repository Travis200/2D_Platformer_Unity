using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This causes the squishable enemies to die when jumped on.
/// This script is attatched to the squisahble enemies hit area (a box collider on top of them) so that we know that the player has 
/// definately jumped on top of them. Note, if the enemy the makes contact with the player with their main collider (not the specific hit area on top),
/// then this will cause the player to die which is demonstrated in the PlayerDeath script.
/// </summary>
public class EnemyDeath : MonoBehaviour

{

    /// <summary>
    /// If the stomp collider (a box collider on the players feet) has collided with enemy's specific hit area 
    /// then will cause the enemy to die.
    /// </summary>
    /// <param name="collision">
    /// Only when the collision is the stomp collider will the enemy die. 
    /// </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StompCollider"))
        {
            FindObjectOfType<AudioManager>().Play("bounce");
            Destroy(transform.parent.gameObject);
            Rigidbody2D rb = collision.transform.parent.GetComponent<Rigidbody2D>();
            //Set velocity to zero so force from falling does not negate the bounciness of jumping on top of squishable enemy.
            rb.velocity = Vector2.zero;
            //Add upwards force so that the player bounces off the squishable enemies when killing them. 
            rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }
    }
}
