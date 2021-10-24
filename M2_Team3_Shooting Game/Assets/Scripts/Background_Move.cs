using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Move : MonoBehaviour
{
    private float offset;
    private float BG_Stop;
    private MeshRenderer renderer;
    private Vector2 PlayerMoveV;
    private Vector2 Moving;

    public float speed;
    public GameObject Player;



    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        Moving = Player.gameObject.transform.position;
        BG_Stop = 0;
    }

    void Update()
    {
        PlayerMoveV = Player.gameObject.transform.position;

        if (PlayerMoveV.x >= Moving.x)
        {
            offset += Time.deltaTime * speed;
            if (PlayerMoveV.x == Moving.x)
            {
                offset = BG_Stop;
            }
            BG_Stop = offset;
        } else if(PlayerMoveV.x <= Moving.x)
        {
            offset -= Time.deltaTime * speed;
            if (PlayerMoveV.x == Moving.x)
            {
                offset = BG_Stop;
            }
            BG_Stop = offset;
        } 
        renderer.material.mainTextureOffset = new Vector2(offset, 0);

        Moving = PlayerMoveV;
    }
}
