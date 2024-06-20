using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Op1Bullet_Script : MonoBehaviour
{
    GameObject option;
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
        this.option = GameObject.Find("Option_1");
        this.status = GameObject.Find("StatusBar");
        Vector3 optionPos = this.option.transform.position;
        transform.position = optionPos;
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