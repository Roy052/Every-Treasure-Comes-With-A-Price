using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingLight : MonoBehaviour
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
        playerPos.y -= 0.5f;
        this.transform.position = playerPos;
    }
}
