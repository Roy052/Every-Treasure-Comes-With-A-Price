using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    Interact interact;
    SpriteRenderer spriteRenderer;
    public Sprite leverUp, leverDown;
    StoneManager stoneManager;

    private void Start()
    {
        interact = this.gameObject.GetComponent<Interact>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        stoneManager = GameObject.Find("StoneManager").GetComponent<StoneManager>();
    }

    private void Update()
    {
        if(interact.inInteract == true && Input.GetKey(KeyCode.E))
        {
            stoneManager.Path();
            StartCoroutine(SpriteChange());
        }
    }

    IEnumerator SpriteChange()
    {
        spriteRenderer.sprite = leverDown;
        yield return new WaitForSeconds(9);
        spriteRenderer.sprite = leverUp;
    }
}
