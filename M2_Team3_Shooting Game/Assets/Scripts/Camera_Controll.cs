using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controll : MonoBehaviour
{
    private Vector3 Camera_Position;

    public GameObject Player;

    void Start()
    {

    }
    
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, 1, -10);

        Camera_Position = this.gameObject.transform.position;
        if (Camera_Position.x >= 82)
        {
            Camera_Position.x = Mathf.Clamp(transform.position.x, 82, 82);
            transform.position = Camera_Position;
        }

        if (Camera_Position.x <= 0)
        {
            Camera_Position.x = Mathf.Clamp(transform.position.x, 0, 0);
            transform.position = Camera_Position;
        }
    }
}
