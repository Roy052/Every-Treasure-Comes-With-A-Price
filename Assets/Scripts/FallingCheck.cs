using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCheck : MonoBehaviour
{
    GameObject player;
    Vector3 playerPos;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        playerPos = player.transform.position;
        playerPos.z = -1;

        playerPos.y -= 0.75f;
        if (this.name == "LeftFoot")
            playerPos.x -= 0.33f;
        else
            playerPos.x += 0.33f;
        this.transform.position = playerPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Void" || collision.tag == "FakeStone")
        {
            if (this.name == "LeftFoot")
                player.GetComponent<CharacterMove>().leftFoot = true;
            else
                player.GetComponent<CharacterMove>().rightFoot = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Void" || collision.tag == "FakeStone")
        {
            if (this.name == "LeftFoot")
                player.GetComponent<CharacterMove>().leftFoot = false;
            else
                player.GetComponent<CharacterMove>().rightFoot = false;
        }
    }
}
