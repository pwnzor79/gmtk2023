using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICollidable : MonoBehaviour
{
    [SerializeField] SpriteRenderer collidableRenderer;
    [SerializeField] Sprite damagedSprite;
    [SerializeField] GameObject otherObject;
    [SerializeField] AudioSource hitSound;
    [SerializeField] float penalty = 0;

    public float Collide()
    {
        if (damagedSprite != null)
        {
            collidableRenderer.sprite = damagedSprite;
        }
        if (hitSound != null)
        {
            hitSound.Play();
        }
        if (otherObject != null)
        {
            otherObject.SetActive(true);
            this.gameObject.SetActive(false);
        }

        return penalty;
    }
}
