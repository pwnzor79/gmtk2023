using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //SceneManager.LoadScene("Floor1");
        //GameManager.instance.currentLevel = "Test Level";
        SceneManager.LoadScene("Test Level");
    }

    public void QuitGame()
    {
        Debug.Log("quitting");
        Application.Quit();
        Debug.Log("why am i still alive?");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void RestartLevel()
    {
        //give gameManager a string for level name, and have it maintain its current level, go to this level.
        if(GameManager.instance.currentLevel == "Test Scene")
        {
            GameManager.instance.time = 200;
        }
        else if(GameManager.instance.currentLevel == "Floor2")
        {
            GameManager.instance.time = 80;
        }
        else
        {
            GameManager.instance.time = 60;
        }
        GameManager.instance.damage = 0;
        SceneManager.LoadScene(GameManager.instance.currentLevel);
    }
}
