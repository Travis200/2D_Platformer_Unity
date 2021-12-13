using UnityEngine;

/// <summary>
/// This script is used to kill the player when certain events occur (such as colliding with an enemy or falling off the map).
/// </summary>
public class PlayerDeath : MonoBehaviour


{

    public Transform respawnPoint1;
    public Transform respawnPoint2;
    public Transform respawnPoint3;
    public Transform respawnPoint4;
    private int _deathCount = 0;

    /// <summary>
    /// This causes the player to die when they collide with an enemy or fall of the map. XP multiplier is reset and also all player stats
    /// (so powerups will become deactivated).
    /// </summary>
    /// <param name="collision">
    /// If the collison is tagged as the "EnemyCollsionDetect" or "DeathZone" (used to mark the edges of the map) this will cause the player to die.
    /// </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyCollisionDetect") || collision.gameObject.CompareTag("DeathZone"))
        {
            Debug.Log("Enemy or death area hit");
            GameObject player = transform.parent.gameObject;
            _deathCount++;
            player.GetComponent<CoinAndXPCollector>().ResetXPMultiplier();
            // Removes all powerups.
            player.GetComponent<Character2DController>().ResetPlayerStats();
/*            gameObject.transform.parent.position = respawnPoint1.position;*/

            if (gameObject.transform.position.x > respawnPoint4.position.x)
            {
                gameObject.transform.parent.position = respawnPoint4.position;
            }
            else if (gameObject.transform.position.x > respawnPoint3.position.x)
            {
                gameObject.transform.parent.position = respawnPoint3.position;
            }
            else if (gameObject.transform.position.x > respawnPoint2.position.x)
            {
                gameObject.transform.parent.position = respawnPoint2.position;
            }
            else
            {
                gameObject.transform.parent.position = respawnPoint1.position;
            }

        }
    }

    /// <summary>
    /// Getter for deathCount
    /// </summary>
    /// <returns>_deathCount</returns>
    public int getDeathCount() 
    {
        return _deathCount;
    }
}
