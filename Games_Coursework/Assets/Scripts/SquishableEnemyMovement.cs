using UnityEngine;

public class SquishableEnemyMovement : MonoBehaviour
{

    public float EnemyMovementSpeed =  4;
    private bool moveRight = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            moveRight = !moveRight;
            Vector3 enemyScale = transform.localScale;
            enemyScale.x *= -1;
            transform.localScale = enemyScale;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {

        if (moveRight)
        {
            transform.Translate(Vector2.right * EnemyMovementSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * EnemyMovementSpeed * Time.deltaTime);
        }
    }
}
