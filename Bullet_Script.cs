using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    GameObject player;
    GameObject status;

    public SpriteRenderer before_img;
    public Sprite after_img;

    public float speed = 0.4f;

    float laser;
    float doubleShot;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        this.player = GameObject.Find("Player");
        this.status = GameObject.Find("StatusBar");
        this.doubleShot = this.status.GetComponent<Status_Script>().statusArray[2];

        Vector3 playerPos = this.player.transform.position;
        if (doubleShot == 1)
        {
            transform.position = new Vector3(playerPos.x + 0.15f, playerPos.y + 0.09f, playerPos.z);
        }
        else
        {
            transform.position = new Vector3(playerPos.x + 0.15f, playerPos.y, playerPos.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        laser = this.status.GetComponent<Status_Script>().statusArray[3];
        transform.Translate(speed, 0, 0);
        if (this.transform.position.x > 10)
            Destroy(gameObject);
        
        if (laser == 2) //Laser(statusBar의 3번째 항목)는 1이 디폴트임
        {
            before_img.sprite = after_img;
        }

    }
}
