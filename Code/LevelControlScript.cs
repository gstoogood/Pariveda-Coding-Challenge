using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour
{
    //Error if this isn't set to null vvvvvv
    public static LevelControlScript instance = null;

    GameObject LevelSign, GameOverText, YouWinText;
    int sceneIndex, levelPassed;
    void Start()
    {
        //sets current levels to the default
        //if it isn't null the current control object is destroyed and next level starts to get generated
        if(instance == null)
        {
            instance = this;
        } else if(instance != this)
        {
            Destroy(gameObject);
        }
        //sets text values to correct level/status
        LevelSign = GameObject.Find("LevelNumber");
        GameOverText = GameObject.Find("GameOverText");
        YouWinText = GameObject.Find("YouWinText");
        GameOverText.gameObject.SetActive(false);
        YouWinText.gameObject.SetActive(false);

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }

    public void PassLevel()
    {
        //on passing a level, respawn count reset and main menu or next level invoked
        Respawn.ResetRespawns();
        if (sceneIndex == 3)
        {
            Invoke("LoadMainMenu", 1f);
        }
        else
        {
            if (levelPassed < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelPassed", sceneIndex);
            }
            LevelSign.gameObject.SetActive(false);
            YouWinText.gameObject.SetActive(true);
            Invoke("LoadNextLevel", 1f);
        }
    }
    public void FailLevel()
    {
        //turns off level text turns on game over text, loads main menu
        LevelSign.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(true);
        Invoke("LoadMainMenu", 1f);
    }
    void LoadNextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
