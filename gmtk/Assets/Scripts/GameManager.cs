using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public float time;
    public int damage;
    public int score;
    public float[] times;
    public int[] damages;

    [SerializeField]
    public PlayerController playerController;

    [SerializeField]
    public string currentLevel;

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
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        times = new float[2];
        damages = new int[2];
    }

    public void loadScene(string sceneName, float time, int pastLevel)
    {
        SceneManager.LoadScene(sceneName);
        times[pastLevel - 1] = this.time;
        damages[pastLevel - 1] = damage;
        damage = 0;
        this.time = time;

    }

}
