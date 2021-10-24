using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameManager GM;

    public GameObject bulletPrefabs;
    public Transform bulletSpawn;
    public Transform RayVector;
    public AudioSource shootSound;

    public bool canShoot = true;
    const float shootDelay = 3.0f;
    public float shootTimer = 0;

    void Start()
    {
        shootSound = GetComponent<AudioSource>();
        shootTimer = 3.0f;
    }

    void Update()
    {
        if(GM.GameStart == true){
            shootControl();
        }
    }

    void shootControl()
    {
        shootTimer += Time.deltaTime;
        if (canShoot)
        {
            if (shootTimer > shootDelay && Input.GetKey(KeyCode.Space))
            {
                Gunfire();
                shootTimer = 0;
            }
        }
    }

    void Gunfire()
    {
        GameObject bullet = Instantiate(bulletPrefabs, bulletSpawn.position, bulletSpawn.rotation);
        if (!shootSound.isPlaying)
        {
            shootSound.Play();
        }
    }
}


