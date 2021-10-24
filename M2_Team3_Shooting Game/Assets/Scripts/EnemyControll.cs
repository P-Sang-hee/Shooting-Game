using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public GameManager GM;
    public AudioSource EnemyDeath_S;
    public float EnemyHP;
    

    void Start()
    {
        EnemyDeath_S = GetComponent<AudioSource>();

        if (this.gameObject.CompareTag("Enemy"))
        {
            EnemyHP = 1;
        }
        if (this.gameObject.CompareTag("Boss"))
        {
            EnemyHP = 8;
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyHP = EnemyHP -1;
            Destroy(collision.gameObject);
            if (EnemyHP == 0)
            {
                if (this.gameObject.CompareTag("Boss"))
                {
                    GM.GameClear = true;
                }
                EnemyDeath_S.Play();
                Destroy(this.gameObject, 0.5f);
            }
        } else if (collision.gameObject.CompareTag("Player"))
        {
            lifemanager.life = lifemanager.life - 1;
        }
    }
    
}
