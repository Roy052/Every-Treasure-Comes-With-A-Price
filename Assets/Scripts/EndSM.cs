using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSM : MonoBehaviour
{
    public Text treasureFound, howmanytimesDied;
    public GameObject dragonEye;
    GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SceneSetUp());
    }

    IEnumerator SceneSetUp()
    {
        yield return new WaitForSeconds(0.5f);

        for(int i = 0; i < 90; i++)
        {
            treasureFound.fontSize += 1;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1);

        howmanytimesDied.text = "You talked with NPC " + PlayerPrefs.GetInt("trynum") + " times";

        yield return new WaitForSeconds(1f);

        dragonEye.GetComponent<DragonEyeOpen>().OpenEye();

        yield return new WaitForSeconds(3f);

        gm.GameEnd();
    }
}
