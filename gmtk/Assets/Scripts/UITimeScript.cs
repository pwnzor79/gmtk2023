using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimeScript : MonoBehaviour
{
    [SerializeField]
    public Text text;

    public float timeRemaining;
    public float levelTime;

    // Start is called before the first frame update
    void Start()
    {
        levelTime = GameManager.instance.time;
        timeRemaining = levelTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //https://docs.unity3d.com/2017.1/Documentation/ScriptReference/UI.Text-text.html
        timeRemaining -= Time.deltaTime;
        text.text = (timeRemaining + " / " + levelTime);
        //text.text = "text";
    }
}
