using UnityEngine;

public class PlayerDeath : MonoBehaviour

{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            LevelController.instance.Respawn();
/*            FindObjectOfType<LevelController>().Player*/
        }
    }
}
