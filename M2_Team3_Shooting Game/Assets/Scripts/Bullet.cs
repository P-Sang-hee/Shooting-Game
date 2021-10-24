using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Bullet_Distance;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Bullet_Distance = 0;
    }
    
    void Update()
    {
        rb.velocity = transform.right * 6.0f;
        Bullet_Distance += Time.deltaTime;
        if(Bullet_Distance >= 2.5)
        {
            Destroy(this.gameObject);
        }
    }
}
