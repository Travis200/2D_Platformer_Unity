using UnityEngine;

public class SquishableEnemyMovement : MonoBehaviour
{

    public float MaxEnemyMovementSpeed =  5f;
    public float MinEnemyMovementSpeed = 2.5f;
    private float EnemyMovementSpeed;
    private bool moveRight = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Wall")) || collision.gameObject.CompareTag("Enemy"))
        {
            FlipEnemy();
        }
    }

    private void Start()
    {
        // This ensures that different squishable enemies move at different speeds to help implement some stochastic behaviour into the game
        EnemyMovementSpeed = Random.Range(MinEnemyMovementSpeed, MaxEnemyMovementSpeed);
        // This makes the enemies change direction at random times to make the games less predictable and helps with the stochastic model
        InvokeRepeating("FlipEnemy", 5f, Random.Range(3f, 10f));
        InvokeRepeating("ChangeEnemySpeed", 5f, Random.Range(3f, 15f));
    }

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

    private void FlipEnemy()
    {
        moveRight = !moveRight;
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

    private void ChangeEnemySpeed()
    {
        EnemyMovementSpeed = Random.Range(MinEnemyMovementSpeed, MaxEnemyMovementSpeed);
    }

}
