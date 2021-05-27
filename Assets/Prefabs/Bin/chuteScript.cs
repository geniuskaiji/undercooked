using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuteScript : MonoBehaviour
{
    public BoxCollider2D collider;
    public SpriteRenderer sprite;
    public Sprite closed;
    public Sprite open;
    public trashScript trashScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if person is holding bag
        // if(holdingBag) {
        sprite.sprite = closed;
        trashScript.setIndexZero();
        trashScript.sprite.sprite = trashScript.sprite1;
        trashScript.index = 0;
        // }
    }
}
