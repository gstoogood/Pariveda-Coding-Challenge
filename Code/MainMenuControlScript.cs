using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControlScript : MonoBehaviour
{
    public Button level1Button, level2Button, level3Button;
    int levelPassed;
    // Start is called before the first frame update
    void Start()
    {
        //when game starts level 2/3 are greyed out
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        level2Button.interactable = false;
        level3Button.interactable = false;

        //if player beats previous levels future levels are unlocked here
        switch(levelPassed)
        {
            case 1:
                level2Button.interactable = true;
                break;
            case 2:
                level2Button.interactable = true;
                level3Button.interactable = true;
                break;
        }
    }
    //Calls correct level #
    public void LevelToLoad(int level)
    {
        SceneManager.LoadScene(level);
    }
    //Resets players progression status
    public void ResetPlayerPrefs()
    {
        level2Button.interactable = false;
        level3Button.interactable = false;
        PlayerPrefs.DeleteAll();
    }
    //exits from game
    public void ExitButton()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
