using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPowerUp : MonoBehaviour

{

    public float SpringJumpDuration = 20f;
    public float SpringJumpPower = 10f;
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
            character2DController.SingleJumpForce = SpringJumpPower;
            character2DController.DoubleJumpForce = 0;
            Debug.Log("Start of wait");
            yield return new WaitForSeconds(SpringJumpDuration);
            Debug.Log("End of wait");
            character2DController.SingleJumpForce = orignalSingleJump;
            character2DController.DoubleJumpForce = orignalDoubleJump;
            gameObject.GetComponent<Renderer>().enabled = true; ;
            PowerupActive = false;
        }
    }
}
