using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Move : MonoBehaviour
{
    private float offset;
    private MeshRenderer renderer;

    public float speed;
    public GameManager GM;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (GM.GameStart == true)
        {
            offset += Time.deltaTime * speed;
            renderer.material.mainTextureOffset = new Vector2(offset, 0);
        }
        
    }
}
