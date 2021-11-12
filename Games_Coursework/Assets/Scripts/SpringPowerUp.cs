using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This script is called when the player collides with the spring powerup and handles activating and deactivating the powerup.
/// </summary>
public class SpringPowerUp : MonoBehaviour

{
    public TextMeshProUGUI PowerupText;
    public float SpringJumpDuration = 20f;
    public float SpringSingleJumpPower = 6f;
    public float SpringDoubleJumpPower = 6f;
    private bool PowerupActive = false;

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
        IEnumerator AcquirePowerUp(Collider2D player) {
            PowerupActive = true;
            gameObject.GetComponent<Renderer>().enabled = false;
            Character2DController character2DController = collision.GetComponent<Character2DController>();
            float orignalSingleJump = character2DController.SingleJumpForce;
            float orignalDoubleJump = character2DController.DoubleJumpForce;
            character2DController.SingleJumpForce = SpringSingleJumpPower;
            character2DController.DoubleJumpForce = SpringDoubleJumpPower;
            PowerupText.text = "Powerup: Springjump";
            PlayerDeath originalPlayerDeath = collision.GetComponentInChildren<PlayerDeath>();
            int originalDeathCount = originalPlayerDeath.getDeathCount();
            yield return new WaitForSeconds(SpringJumpDuration);
            PlayerDeath newPlayerDeath = collision.GetComponentInChildren<PlayerDeath>();
            int newDeathCount = originalPlayerDeath.getDeathCount();
            Debug.Log("Spring Jump Powerup Expired");
            if (originalDeathCount == newDeathCount)
            {
                PowerupText.text = "Powerup: None";
                character2DController.SingleJumpForce = orignalSingleJump;
                character2DController.DoubleJumpForce = orignalDoubleJump;
            }
            
            gameObject.GetComponent<Renderer>().enabled = true; ;
            PowerupActive = false;
        }
    }

}
