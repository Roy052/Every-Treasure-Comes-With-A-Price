using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peaks : MonoBehaviour
{
    public bool isactivated = false;
    public bool isMoving = true;
    GameObject player;
    Animator animator;

    private void Start()
    {
        player = GameObject.Find("Player");
        animator = this.gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && isactivated)
        {
            animator.SetBool("Activate", true);
            player.GetComponent<CharacterMove>().Death_Trap();
        }
    }

    public IEnumerator PeakUpDown()
    {
        animator.SetBool("UpDownActivate", true);
        while (isMoving)
        {
            isactivated = false;
            yield return new WaitForSeconds(0.2f);
            isactivated = true;
            yield return new WaitForSeconds(1f);
            isactivated = false;
            yield return new WaitForSeconds(0.4f);
        }
        
        
    }
}
