using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameManager GM;

    public const float moveSpeed = 5.0f;
    public bool isWalking;
    public AudioSource walkSound;

    Animator Player_walk;


    void Start()
    {
        Player_walk = gameObject.GetComponent<Animator>();
        walkSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GM.GameStart == true)
        {
            moveControl();
        }
        
    }

    void moveControl()
    {
        Player_walk.SetBool("IsWalking", true);
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        this.gameObject.transform.Translate(distanceX, 0, 0);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
        transform.position = worldPos; //좌표를 적용한다.
        

        if (!walkSound.isPlaying)
        {
            walkSound.Play();
        }
        
        if (distanceX == 0)
        {
            Player_walk.SetBool("IsWalking", false);
            walkSound.Stop();
        }


    }
}
