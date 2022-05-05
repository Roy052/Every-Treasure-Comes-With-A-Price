using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapse : MonoBehaviour
{
    Animator animator;
    GameManager gm;
    GameObject player;

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            if(gm.gameState == 1)
            {
                animator.SetBool("Occur", true);
                gm.Fall();
            }
            else if(gm.gameState == 2)
            {
                animator.SetBool("FastOccur", true);
                player.GetComponent<CharacterMove>().Death_Fall();
                gm.GameOver();
            }
        }
    }

    
}
