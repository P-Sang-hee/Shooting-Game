using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public GameObject TitleImg;
    public GameObject gameClearImg;
    public GameObject gameOverImg;
    public GameObject Start_Btn;
    public GameObject Restart_Btn;

    public AudioSource Main_BGM;
    public AudioSource GameOver_BGM;
    public AudioClip MainBGM;
    public AudioClip OverBGM;

    public bool GameStart;
    public bool GameClear;
    public bool GameOver;

    public int BGM_PlayCount;


    void Start()
    {
        GameStart = false;
        GameClear = false;
        GameOver = false;
        Time.timeScale = 0f;
        BGM_PlayCount=0;
    }
    
    void Update()
    {
        if(GameStart == true)
        {
            Time.timeScale = 1.0f;
            TitleImg.SetActive(false);
            Start_Btn.SetActive(false);
            if (!Main_BGM.isPlaying)
            {
                Main_BGM.PlayOneShot(MainBGM);
            }
        }

        if (GameClear == true)
        {
            GameStart = false;
            StartCoroutine("gameClear");
        }

        if (GameOver == true)
        {
            GameStart = false;
            StartCoroutine("Over_Game");
        }
        
    }

    IEnumerator gameClear()
    {
        yield return new WaitForSeconds(0.6f);
        Main_BGM.Stop();
        iTween.FadeTo(gameClearImg, iTween.Hash("alpha", 255, "time", 1f));
        yield return new WaitForSeconds(1f);
        Restart_Btn.SetActive(true);
        Time.timeScale = 0f;
    }

    IEnumerator Over_Game()
    {
        Main_BGM.Stop();
        if (!GameOver_BGM.isPlaying && BGM_PlayCount == 0)
        {
            GameOver_BGM.PlayOneShot(OverBGM);
            BGM_PlayCount += 1;
        } else if (BGM_PlayCount >= 1)
        {
            yield return new WaitForSeconds(3f);
            GameOver_BGM.Stop();
        }
        iTween.FadeTo(gameOverImg, iTween.Hash("alpha", 255, "time", 1f));
        yield return new WaitForSeconds(1f);
        Restart_Btn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        GameStart = true;
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }
    
}
