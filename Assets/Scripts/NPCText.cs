using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCText : MonoBehaviour
{
    string[] texts = { "Go home!", "Why are you here?", "Nothing in here.", "Didn't someone call you a fool?", "You like treasure.\nBut treasure hates you", "Are you getting tired of falling?" };
    Text npc_text;
    bool incollision = false;

    private void Start()
    {
        npc_text = GameObject.Find("npc_text").GetComponent<Text>();
    }

    private void Update()
    {
        if(incollision == true && Input.GetKey(KeyCode.E))
        {
            npc_text.text = "Many explorers are\nnever came back.";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            if (PlayerPrefs.GetInt("trynum") < texts.Length)
                npc_text.text = texts[PlayerPrefs.GetInt("trynum")];
            else
                npc_text.text = texts[Random.Range(1, texts.Length)];
            PlayerPrefs.SetInt("trynum", PlayerPrefs.GetInt("trynum") + 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Player")
            incollision = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
            incollision = false;
    }
}
