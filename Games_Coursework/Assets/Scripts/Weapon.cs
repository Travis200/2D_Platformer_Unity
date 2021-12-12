using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Debug.Log("fire - ahooting point pos");
        Debug.Log(shootingPoint.rotation);
        // Instantiate a bullet at the shooting point when the fire1 key is pressed
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
    }
}
