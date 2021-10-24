using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifemanager : MonoBehaviour
{
    public GameManager GM;
    public static int life = 3;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public AudioSource Hit_BGM;
    public AudioClip HitBGM;
    
    public int BGM_PlayCount;

    void Start()
    {
        life = 3;
        life3.SetActive(true);
        life2.SetActive(true);
        life1.SetActive(true);

        BGM_PlayCount = 3;
    }

    void Update()
    {
        switch (life)
        {
            case 2:
                life3.SetActive(false);
                if (!Hit_BGM.isPlaying && BGM_PlayCount == 3)
                {
                    StartCoroutine("Wait");
                }
                else if (BGM_PlayCount <= 2)
                {
                    Hit_BGM.Stop();
                }
                break;
            case 1:
                life2.SetActive(false);
                if (!Hit_BGM.isPlaying && BGM_PlayCount == 2)
                {
                    StartCoroutine("Wait");
                }
                else if (BGM_PlayCount <= 1)
                {
                    Hit_BGM.Stop();
                }
                break;
            case 0:
                life1.SetActive(false);
                GM.GameOver = true;
                break;
        }
    }

    IEnumerator Wait()
    {
        Hit_BGM.PlayOneShot(HitBGM);
        yield return new WaitForSeconds(0.6f);
        BGM_PlayCount = BGM_PlayCount - 1;
    }
}
