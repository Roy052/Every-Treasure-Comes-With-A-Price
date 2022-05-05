using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    Interact interact;
    SpriteRenderer spriteRenderer;
    public Sprite treaureUp, treasureDown;
    GameManager gm;
    bool otp = false;

    private void Start()
    {
        interact = this.gameObject.GetComponent<Interact>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (interact.inInteract == true && Input.GetKey(KeyCode.E) && otp == false)
        {
            spriteRenderer.sprite = treasureDown;
            gm.GameClear();
            otp = true;
        }
    }
}

