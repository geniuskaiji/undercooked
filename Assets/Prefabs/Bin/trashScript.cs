using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    public SpriteRenderer otherSprite;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite open;
    public BoxCollider2D collider;
    public int index = 0;
    void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (index == 0)
        {
            index += 1;
            sprite.sprite = sprite2;
        }
        if (index >= 1 & index <= 5)
        {
            index += 1;
        }
        if (index == 6)
        {
            sprite.sprite = sprite3;
            giveGarbageBag();
            otherSprite.sprite = open;
        }
    }

    public void setIndexZero()
    {
        index = 0;
    }
    private void giveGarbageBag()
    {
        //Animation To Give Garbage Bag To Player
    }
}
