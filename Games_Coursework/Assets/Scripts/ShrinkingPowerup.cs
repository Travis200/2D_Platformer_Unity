using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPowerup : MonoBehaviour
{
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
            Vector3 OriginalPlayerScale = character2DController.TransformPlayer.localScale;
            character2DController.TransformPlayer.localScale = OriginalPlayerScale * ScaleMultiplier;
            Debug.Log("Start of wait");
            yield return new WaitForSeconds(ShrinkDuration);
            Debug.Log("End of wait");
            character2DController.TransformPlayer.localScale = OriginalPlayerScale;
            gameObject.GetComponent<Renderer>().enabled = true; ;
            PowerupActive = false;
        }
    }
}
