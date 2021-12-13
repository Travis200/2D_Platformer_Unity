using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to control the shooting mechanic and instantiate bullets into the game 
/// </summary>
public class Weapon : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bullet;
    public bool weaponActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && weaponActive)
        {
            Fire();
        }
    }

    private void Fire()
    {
        // Instantiate a bullet at the shooting point when the fire1 key is pressed
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
    }
}
