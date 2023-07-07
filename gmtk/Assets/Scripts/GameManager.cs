using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public float time;
    public int health;
    public int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if(instance == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

    }

}
