using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUIScript : MonoBehaviour
{
    private int currentDamage = 6;

    [SerializeField]
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    public Sprite zeroDamage;

    [SerializeField]
    public Sprite oneDamage;

    [SerializeField]
    public Sprite twoDamage;

    [SerializeField]
    public Sprite threeDamage;

    [SerializeField]
    public Sprite fourDamage;

    [SerializeField]
    public Sprite fiveDamage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //i know this is ugly don't be mean to it
        if(GameManager.instance.damage != currentDamage)
        {
            switch(GameManager.instance.damage)
            {
                case 0:
                    //set animation to 0Damage
                    spriteRenderer.sprite = zeroDamage;
                    break;

                case 1:
                    //set animation to 0Damage
                    spriteRenderer.sprite = oneDamage;
                    break;

                case 2:
                    //set animation to 0Damage
                    spriteRenderer.sprite = twoDamage;
                    break;

                case 3:
                    //set animation to 0Damage
                    spriteRenderer.sprite = threeDamage;
                    break;

                case 4:
                    //set animation to 0Damage
                    spriteRenderer.sprite = fourDamage;
                    break;

                case 5:
                    //set animation to 0Damage
                    spriteRenderer.sprite = fiveDamage;
                    break;

                default:
                    spriteRenderer.sprite = fiveDamage;
                    break;
            }
        }

    }
}
