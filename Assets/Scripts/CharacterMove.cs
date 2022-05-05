using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    bool movable = true;
    GameManager gm;

    float speed = 3f;
    Rigidbody2D rb2D;
    Vector2 movement;
    Animator animator;
    bool faceLeft = false;
    StoneManager stoneManager;

    public bool leftFoot = false, rightFoot = false;

    private void Start()
    {
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(gm.gameState == 2)
            stoneManager = GameObject.Find("StoneManager").GetComponent<StoneManager>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Move", movement.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        if (leftFoot == true && rightFoot == true)
        {
            Death_Fall();
            leftFoot = false;
            rightFoot = false;
            stoneManager.Dissapearance();
        }
        if (movable)
        {
            rb2D.MovePosition(rb2D.position + movement * speed * Time.fixedDeltaTime);
        }

        if ((movement.x < 0 && faceLeft == false) || (movement.x > 0 && faceLeft == true))
        {
            faceLeft = !faceLeft;
            this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
        }
        

    }

    public void DontMove()
    {
        movable = false;
        animator.enabled = false;
    }

    public void TimeToMove()
    {
        movable = true;
        animator.enabled = true;
    }

    public void Fall()
    {
        movable = false;
        StartCoroutine(Falling());
    }

    public void Death_Fall()
    {
        movable = false;
        animator.SetBool("Death_Fall", true);
        gm.GameOver();
    }

    public void Death_Trap()
    {
        movable = false;
        animator.SetBool("Death_Trap", true);
        gm.GameOver();
    }

    IEnumerator Falling()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Death_Fall", true);
    }
}
