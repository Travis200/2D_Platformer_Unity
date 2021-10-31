using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public Transform respawnPos;
    public GameObject playerPrefab;


    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        Instantiate(playerPrefab, respawnPos.position, Quaternion.identity);
    }

}