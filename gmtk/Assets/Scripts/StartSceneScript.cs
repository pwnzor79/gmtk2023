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
        SceneManager.LoadScene("BobbyScene1");
    }

    public void QuitGame()
    {
        Debug.Log("quitting");
        Application.Quit();
        Debug.Log("why am i still alive?");
    }
}
