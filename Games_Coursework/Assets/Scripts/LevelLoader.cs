using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is used to load the the level depending on which level the player selected from the level select scene. 
/// </summary>
public class LevelLoader : MonoBehaviour
{
    /// <summary>
    /// Loads the selected level.
    /// </summary>
    public void LoadLevel ()
    {
        string levelSelected = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(levelSelected);
    }
}
