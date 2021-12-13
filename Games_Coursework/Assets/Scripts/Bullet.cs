using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
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
