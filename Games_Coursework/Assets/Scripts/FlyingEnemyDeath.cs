using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyDeath : MonoBehaviour
{

    public int bulletsUntilDeath = 5;

    public void TakeDamage()
    {
        bulletsUntilDeath--;

        if (bulletsUntilDeath <= 0)
        {
            Destroy(gameObject);
        }
    }
}
