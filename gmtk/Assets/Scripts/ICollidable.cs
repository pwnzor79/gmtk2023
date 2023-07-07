using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICollidable : MonoBehaviour
{
    [SerializeField] SpriteRenderer collidableRenderer;
    [SerializeField] Sprite damagedSprite;
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

        return penalty;
    }
}
