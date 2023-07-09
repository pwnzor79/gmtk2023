using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ElevatorScript : MonoBehaviour
{

    public string nextLevel;

    public float nextLevelTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.currentLevel = nextLevel;
        GameManager.instance.damage = 0;
        GameManager.instance.time = nextLevelTime;
        SceneManager.LoadScene("Floor2");
    }
}