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
        Debug.Log(levelSelected);
        SceneManager.LoadScene(levelSelected);

        /*        if  (levelSelected == "Level_1")
                {
                    SceneManager.LoadScene("Scene_1");
                }

                else if (levelSelected == "Level_2")
                {
                    SceneManager.LoadScene("Scene_2");
                }
                else if (levelSelected == "Level_3")
                {
                    SceneManager.LoadScene("Scene_3");
                }*/


    }
}
