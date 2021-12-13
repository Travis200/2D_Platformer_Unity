using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This script is called when the player collides with the shrinking powerup and handles activating and deactivating the powerup.
/// </summary>
public class ShrinkingPowerup : MonoBehaviour
{
    public TextMeshProUGUI PowerupText;
    public float ShrinkDuration = 20f;
    private bool PowerupActive = false;
    private float ScaleMultiplier = 0.5f;
    [SerializeField] private GameObject pickupEffect;

    /// <summary>
    /// When the player collides with the powerup, this causes the powerup to be acquired which is implemented here (and deactivated).
    /// </summary>
    /// <param name="collision">
    /// Refers to the the object collided with - if it is the player then the powerup is acquired
    /// </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !PowerupActive)
        {
            // Coroutine is used so that the powerup can expire. 
            StartCoroutine(AcquirePowerUp(collision));
        }

        // Powerup is applied to the player on a for a set period of time before being removed.
        IEnumerator AcquirePowerUp(Collider2D player)
        {
            PowerupActive = true;
            Instantiate(pickupEffect, transform.position, transform.rotation);
            gameObject.GetComponent<Renderer>().enabled = false;
            FindObjectOfType<AudioManager>().Play("powerup");
            Character2DController character2DController = collision.GetComponent<Character2DController>();
            Vector3 playerScale = character2DController.TransformPlayer.localScale;
            playerScale *= ScaleMultiplier;
            character2DController.TransformPlayer.localScale = playerScale;
            Debug.Log("Shrinking PU scale 1" + character2DController.TransformPlayer.localScale);
            PowerupText.text = "Powerup: Shrink";
            PlayerDeath originalPlayerDeath = collision.GetComponentInChildren<PlayerDeath>();
            int originalDeathCount = originalPlayerDeath.getDeathCount();
            yield return new WaitForSeconds(ShrinkDuration);
            PlayerDeath newPlayerDeath = collision.GetComponentInChildren<PlayerDeath>();
            int newDeathCount = originalPlayerDeath.getDeathCount();
            Debug.Log("shrink powerup expired");

            //  Only reverts the powerup if the player has not dies while it was active (player stats are reset upon death)
            if (originalDeathCount == newDeathCount)
            {
                PowerupText.text = "Powerup: None";
                playerScale = character2DController.TransformPlayer.localScale;
                playerScale /= ScaleMultiplier;
                character2DController.TransformPlayer.localScale = playerScale;
            }


            gameObject.GetComponent<Renderer>().enabled = true;
            PowerupActive = false;
        }
    }
}
