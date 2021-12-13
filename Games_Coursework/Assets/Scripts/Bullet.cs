using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to add velocity to a bullet and so that it destroys when it makes impact with an enemy.
/// </summary>
public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.CompareTag("EnemyCollisionDetect"))
        {
            collision.gameObject.GetComponent<FlyingEnemyDeath>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
