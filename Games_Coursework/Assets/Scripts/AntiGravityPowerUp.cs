using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravityPowerUp : MonoBehaviour
{
    public float AntiGravityDuration = 20f;
    private bool PowerupActive = false;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !PowerupActive)
        {
            StartCoroutine(AcquirePowerUp(collision));
        }

        IEnumerator AcquirePowerUp(Collider2D player)
        {
            Debug.Log("Poweup Acquired!!!!");
            PowerupActive = true;
            gameObject.GetComponent<Renderer>().enabled = false;
            Character2DController character2DController = collision.GetComponent<Character2DController>();
            InvertGravityAndRotation(character2DController);
            Debug.Log("Anti-Gravity PU scale 1" + character2DController.TransformPlayer.localScale);
            yield return new WaitForSeconds(AntiGravityDuration);
            InvertGravityAndRotation(character2DController);
            Debug.Log("Anti-Gravity PU scale 1" + character2DController.TransformPlayer.localScale);
            gameObject.GetComponent<Renderer>().enabled = true;
            PowerupActive = false;
        }

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
