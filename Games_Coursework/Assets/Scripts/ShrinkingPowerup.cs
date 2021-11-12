using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShrinkingPowerup : MonoBehaviour
{
    public TextMeshProUGUI PowerupText;
    public float ShrinkDuration = 20f;
    private bool PowerupActive = false;
    private float ScaleMultiplier = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !PowerupActive)
        {
            StartCoroutine(AcquirePowerUp(collision));
        }

        IEnumerator AcquirePowerUp(Collider2D player)
        {
            PowerupActive = true;
            gameObject.GetComponent<Renderer>().enabled = false;
            Character2DController character2DController = collision.GetComponent<Character2DController>();
            Vector3 playerScale = character2DController.TransformPlayer.localScale;
            playerScale *= ScaleMultiplier;
            character2DController.TransformPlayer.localScale = playerScale;
            Debug.Log("Shrinking PU scale 1" + character2DController.TransformPlayer.localScale);
            PowerupText.text = "Powerup: Shrink";
            yield return new WaitForSeconds(ShrinkDuration);
            Debug.Log("shrink powerup expired");
            PowerupText.text = "Powerup: None";
            playerScale = character2DController.TransformPlayer.localScale;
            playerScale /= ScaleMultiplier;
            character2DController.TransformPlayer.localScale = playerScale;

            gameObject.GetComponent<Renderer>().enabled = true;
            PowerupActive = false;
        }
    }
}
