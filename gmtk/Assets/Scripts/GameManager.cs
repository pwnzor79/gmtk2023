using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public float time;
    public int health;
    public int score;

    [SerializeField]
    public PlayerController playerController;

    public FrictionArea currentFrictionArea;

    //STORE THE DEFAULT VALUES FOR PLAYER DRAG
    public float defaultDrag;
    public float defaultAngularDrag;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
