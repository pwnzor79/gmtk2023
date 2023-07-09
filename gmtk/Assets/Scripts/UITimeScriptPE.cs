using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UITimeScriptPE : MonoBehaviour
{
    [SerializeField]
    public Text text;
    public bool time = true;
    public bool grade = false;

    public int index;

    public float levelTime;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        levelTime = GameManager.instance.times[index];
        damage = GameManager.instance.damages[index];
    }

    private void FixedUpdate()
    {
        if (time && !grade)
        {
            //https://docs.unity3d.com/2017.1/Documentation/ScriptReference/UI.Text-text.html
            text.text = ($"{levelTime:F2} / ");
        }
        else if (grade)
        {
         //   if (GameManager.instance.times[index] )
        }
        else
        {
            text.text = ("" + damage);
        }
    }
}
