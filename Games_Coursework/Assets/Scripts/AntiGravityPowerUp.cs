using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This script is called when the player collides with the anti-gravity powerup and handles activating and deactivating the powerup.
/// </summary>
public class AntiGravityPowerUp : MonoBehaviour
{
    public TextMeshProUGUI PowerupText;
    public float AntiGravityDuration = 20f;
    private bool PowerupActive = false;
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
            Debug.Log("Poweup Acquired!!!!");
            PowerupActive = true;
            Instantiate(pickupEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("powerup");
            gameObject.GetComponent<Renderer>().enabled = false;
            Character2DController character2DController = collision.GetComponent<Character2DController>();
            InvertGravityAndRotation(character2DController);
            Debug.Log("Anti-Gravity PU scale 1" + character2DController.TransformPlayer.localScale);
            PowerupText.text = "Powerup: Anti-gravity";
            PlayerDeath originalPlayerDeath = collision.GetComponentInChildren<PlayerDeath>();
            int originalDeathCount = originalPlayerDeath.getDeathCount();
            yield return new WaitForSeconds(AntiGravityDuration);
            PlayerDeath newPlayerDeath = collision.GetComponentInChildren<PlayerDeath>();
            int newDeathCount = originalPlayerDeath.getDeathCount();
            Debug.Log("Anti-gravity powerup expired");
            if (originalDeathCount == newDeathCount)
            {
                PowerupText.text = "Powerup: None";
                InvertGravityAndRotation(character2DController);
            }
            Debug.Log("Anti-Gravity PU scale 1" + character2DController.TransformPlayer.localScale);
            
            gameObject.GetComponent<Renderer>().enabled = true;
            PowerupActive = false;
        }

        /// <summary>
        /// This method inverts the gravity, and the players y scale (so they appear upside down), and also inverts the jump force. 
        /// </summary>
        void InvertGravityAndRotation(Character2DController character2DController)
        {
            Vector3 playerScale = character2DController.transform.localScale;
            playerScale.y *= -1;
            character2DController.transform.localScale = playerScale;
            character2DController.rb.gravityScale *= -1;
            character2DController.SingleJumpForce *= -1;
            character2DController.DoubleJumpForce *= -1;
        }
    }
}
