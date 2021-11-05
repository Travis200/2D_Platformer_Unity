using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel ()
    {
        string levelSelected = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(levelSelected);
    }
}
