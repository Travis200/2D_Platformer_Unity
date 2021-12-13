using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to activate the ability to shoot when the pistol is picked up
/// </summary>
public class WeaponPowerUpCollect : MonoBehaviour
{

    [SerializeField] private GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player collected gun");
            Instantiate(pickupEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("powerup");
            Weapon weapon = collision.GetComponent<Weapon>();
            weapon.weaponActive = true;
            Destroy(gameObject);
        }
    }
}
