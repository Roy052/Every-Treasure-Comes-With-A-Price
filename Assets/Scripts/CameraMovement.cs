using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
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
        playerPos.z = -5;
        this.transform.position = playerPos;
    }
}
