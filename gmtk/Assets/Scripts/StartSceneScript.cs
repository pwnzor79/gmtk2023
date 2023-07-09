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
        SceneManager.LoadScene(GameManager.instance.currentLevel);
    }
}
