using UnityEngine;

public class PlayerDeath : MonoBehaviour

{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
            LevelController.instance.Respawn();
        }
    }
}
