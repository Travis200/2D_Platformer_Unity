using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpringPowerUp : MonoBehaviour

{
    public TextMeshProUGUI PowerupText;
    public float SpringJumpDuration = 20f;
    public float SpringSingleJumpPower = 6f;
    public float SpringDoubleJumpPower = 6f;
    private bool PowerupActive = false;



    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !PowerupActive)
        {
            StartCoroutine(AcquirePowerUp(collision));
        }

        IEnumerator AcquirePowerUp(Collider2D player) {
            PowerupActive = true;
            gameObject.GetComponent<Renderer>().enabled = false;
            Character2DController character2DController = collision.GetComponent<Character2DController>();
            float orignalSingleJump = character2DController.SingleJumpForce;
            float orignalDoubleJump = character2DController.DoubleJumpForce;
            character2DController.SingleJumpForce = SpringSingleJumpPower;
            character2DController.DoubleJumpForce = SpringDoubleJumpPower;
            PowerupText.text = "Powerup: Springjump";
            yield return new WaitForSeconds(SpringJumpDuration);
            Debug.Log("Spring Jump Powerup Expired");
            PowerupText.text = "Powerup: None";
            if (character2DController != null)
            {
                character2DController.SingleJumpForce = orignalSingleJump;
                character2DController.DoubleJumpForce = orignalDoubleJump;
            }
            gameObject.GetComponent<Renderer>().enabled = true; ;
            PowerupActive = false;
        }
    }

}
