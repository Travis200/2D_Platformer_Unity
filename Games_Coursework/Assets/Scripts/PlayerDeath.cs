using UnityEngine;

public class PlayerDeath : MonoBehaviour

{

    /*    private void OnCollisionEnter2D(Collision2D collision)
        {

            if ((collision.gameObject.CompareTag("Enemy")) || collision.gameObject.CompareTag("DeathZone"))
            {
                Debug.Log("Enemy or death area hit");
                Destroy(gameObject);
                LevelController.instance.Respawn();
            }
        }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyCollisionDetect") || collision.gameObject.CompareTag("DeathZone"))
        {
            Debug.Log("Enemy or death area hit");
            Destroy(transform.parent.gameObject);
            LevelController.instance.Respawn();
        }
    }
}
