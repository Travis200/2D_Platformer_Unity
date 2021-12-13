using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to cause the eagles death when it is shot with the specified number of bullets. 
public class FlyingEnemyDeath : MonoBehaviour
{

    public int bulletsUntilDeath = 5;
    public GameObject powerUp;
    [SerializeField] private Weapon weapon;

    public void TakeDamage()
    {
        bulletsUntilDeath--;

        if (bulletsUntilDeath <= 0)
        {
            // Drop a shrinking powerup in the position where the eagle dies
            Instantiate(powerUp, transform.position, transform.rotation);
            // Destroy eagle
            Destroy(gameObject);
            // Deactivate weapon when eagle is destroyed
            weapon.weaponActive = false;
        }
    }
}
