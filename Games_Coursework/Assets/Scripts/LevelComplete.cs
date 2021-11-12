using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is used to exit the level back to the main menu screen.
/// </summary>
public class LevelComplete : MonoBehaviour
{
    /// <summary>
    /// This exits the level when the player reaches the flag. 
    /// </summary>
    /// <param name="collision">Check that the player has collided with a a flag (instead of an enemy for example).</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level_Select");
        }
    }
}
