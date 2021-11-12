using UnityEngine;

/// <summary>
/// This script is used to kill the player when certain events occur (such as colliding with an enemy or falling off the map).
/// </summary>
public class PlayerDeath : MonoBehaviour


{

    public GameObject respawnPos;

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
            player.GetComponent<CoinAndXPCollector>().ResetXPMultiplier();
            // Removes all powerups.
            player.GetComponent<Character2DController>().ResetPlayerStats();
            gameObject.transform.parent.position = respawnPos.transform.position;

        }
    }
}
