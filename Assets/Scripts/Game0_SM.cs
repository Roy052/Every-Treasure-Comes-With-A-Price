using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game0_SM : MonoBehaviour
{
    GameObject[] savePointGates, savePointWalls;
    GameManager gm;

    private void Start()
    {
        savePointGates = GameObject.FindGameObjectsWithTag("SavePointGate");
        savePointWalls = GameObject.FindGameObjectsWithTag("SavePointWall");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        switch (gm.savePoint)
        {
            case 0:
                savePointGates[0].SetActive(false);
                savePointGates[1].SetActive(false);
                break;
            case 1:
                savePointGates[1].SetActive(false);
                savePointWalls[0].SetActive(false);
                break;
            case 2:
                savePointWalls[0].SetActive(false);
                savePointWalls[1].SetActive(false);
                break;
        }
    }
}
