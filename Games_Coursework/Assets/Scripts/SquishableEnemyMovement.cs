using UnityEngine;

/// <summary>
/// This class controls all of the the squishable enemies movement. 
/// </summary>
public class SquishableEnemyMovement : MonoBehaviour
{

    public float MaxEnemyMovementSpeed =  5f;
    public float MinEnemyMovementSpeed = 2.5f;
    private float EnemyMovementSpeed;
    private bool moveRight = false;

    /// <summary>
    /// Changes direction of enemy movement when there hit a wall or another enemy. 
    /// </summary>
    /// <param name="collision">
    /// Refers to the the object collided with - only if the object has a tag of  a wall or another enemy will it cause the enemy to change direction.
    /// </param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Wall")) || collision.gameObject.CompareTag("Enemy"))
        {
            FlipEnemy();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        // This ensures that different squishable enemies move at different speeds to help implement some stochastic behaviour into the game.
        EnemyMovementSpeed = Random.Range(MinEnemyMovementSpeed, MaxEnemyMovementSpeed);
        // This makes the enemies change direction at random times to make the games less predictable and helps with the stochastic model.
        InvokeRepeating("FlipEnemy", 5f, Random.Range(3f, 10f));
        InvokeRepeating("ChangeEnemySpeed", 5f, Random.Range(3f, 15f));
    }

    private void Update()
    {
        Patrol();
    }

    /// <summary>
    /// This causes the enemy to move in a direction which is dependant on the moveRight boolean. 
    /// </summary>
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

    /// <summary>
    /// Changes the travel direction and flips the sprite of an enemy to face the other way.
    /// </summary>
    private void FlipEnemy()
    {
        moveRight = !moveRight;
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

    /// <summary>
    /// Change the enemy speed to a random range between those specified in the min and max MovementSpeed variables.
    /// </summary>
    private void ChangeEnemySpeed()
    {
        EnemyMovementSpeed = Random.Range(MinEnemyMovementSpeed, MaxEnemyMovementSpeed);
    }

}
