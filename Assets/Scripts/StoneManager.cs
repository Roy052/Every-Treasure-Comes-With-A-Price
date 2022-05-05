using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    GameObject[] stones;
    GameObject[] fakeStones;
    // OXOOO
    // XXOOO
    // XOXXX
    // XXXOX
    // OOOOX

    private void Start()
    {
        stones = GameObject.FindGameObjectsWithTag("Stone");
        fakeStones = GameObject.FindGameObjectsWithTag("FakeStone");
    }

    public void Path()
    {
        StartCoroutine(PathFinder());
    }

    IEnumerator PathFinder()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 12; i++)
        {
            stones[i].GetComponent<Stone>().Blight();
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void Dissapearance()
    {
        StopCoroutine(PathFinder());
        for (int i = 0; i < stones.Length; i++)
        {
            stones[i].SetActive(false);
        }
        for (int i = 0; i < fakeStones.Length; i++)
        {
            fakeStones[i].SetActive(false);
        }
    }
}
