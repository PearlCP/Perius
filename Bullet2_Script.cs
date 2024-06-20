using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet2_Script : MonoBehaviour
{
    GameObject player;
    GameObject status;

    public SpriteRenderer before_img;
    public Sprite after_img;

    public float speed = 0.4f;

    float laser;
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
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(playerPos.x + 0.15f, playerPos.y - 0.09f, playerPos.z);
    }
    // Update is called once per frame
    void Update()
    {
        laser = this.status.GetComponent<Status_Script>().statusArray[3];
        transform.Translate(speed, 0, 0);
        if (this.transform.position.x > 10)
            Destroy(gameObject);

        if (laser == 2)
        {
            before_img.sprite = after_img;
        }
    }
}