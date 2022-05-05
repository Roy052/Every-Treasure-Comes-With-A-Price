using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int gameState = 0; //0 : Menu, 1 : Map0, 2 : Map1, 3 : End
    public int savePoint = 0;
    GameObject player;
    Animator animator;
    float timer = 0;
    
    void Start()
    {
        DontDestroyOnLoad(this);
        player = GameObject.Find("Player");
        animator = this.gameObject.GetComponent<Animator>();
        PlayerPrefs.SetInt("trynum", 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer >= 0.5)
        {
            player = GameObject.Find("Player");
            timer = 0;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Map0");
        gameState = 1;
        player = GameObject.Find("Player");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Map0");
        gameState = 1;
        player = GameObject.Find("Player");
    }
    public void Fall()
    {
        player.GetComponent<CharacterMove>().Fall();
        StartCoroutine(DelayedCollapse());
    }
    public void GameOver()
    {
        StartCoroutine(DelayedScene("Map0", 1));
    }

    public void GameClear()
    {
        StartCoroutine(DelayedScene("End", 3));
    }

    public void GameEnd()
    {
        StartCoroutine(DelayedScene("Menu", 0));
    }

    IEnumerator DelayedCollapse()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("Fade_Out", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Map1");
        animator.SetBool("Fade_Out", false);
        gameState = 2;
        player = GameObject.Find("Player");
    }

    IEnumerator DelayedScene(string sceneName, int gameStateNum)
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("Fade_Out", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
        animator.SetBool("Fade_Out", false);
        gameState = gameStateNum;
    }
}
