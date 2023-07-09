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
    public GameObject A;
    public GameObject B;
    public GameObject C;

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
            text.text = ($"{levelTime:F2}");
        }
        else if (grade)
        {
            if (index == 0)
            {
                if (levelTime + (damage * 5) < 32)
                {
                    text.text = "A";
                }
                if (levelTime + (damage * 5) < 42)
                {
                    text.text = "B";
                }
                else
                {
                    text.text = "C";
                }
                if (text.text.Equals("B"))
                {
                    B.SetActive(true);
                }
                else if (text.text.Equals("A"))
                {
                    if (GameManager.instance.times[1] + (GameManager.instance.damages[1] * 5) < 47)
                    {
                        A.SetActive(true);
                    }
                    else
                    {
                        B.SetActive(true);
                    }
                }
                else
                {
                    if (GameManager.instance.times[1] + (GameManager.instance.damages[1] * 5) < 57)
                    {
                        B.SetActive(true);
                    }
                    else
                    {
                        C.SetActive(true);
                    }
                }
            }
            if (index == 1)
            {
                if (levelTime + (damage * 5) < 47)
                {
                    text.text = "A";
                }
                if (levelTime + (damage * 5) < 57)
                {
                    text.text = "B";
                }
                else
                {
                    text.text = "C";
                }
            }
        }
        else
        {
            text.text = ("" + damage);
        }
    }
}
