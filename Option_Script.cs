using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option_Script : MonoBehaviour
{
    GameObject status;
    GameObject player;

    public GameObject bullet_prefab;

    public float speed = 0.07f;
    public float distance_limit;

    float distance_to_other;
    float delta = 0;
    float delay = 0.09f;
    // Start is called before the first frame update
    void Start()
    {
        this.status = GameObject.Find("StatusBar");
        this.player = GameObject.Find("Player");
        transform.position = player.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        speed = status.GetComponent<Status_Script>().statusArray[0];
        float distance_to_other = Vector2.Distance(this.transform.position, player.transform.position);
        MovingOption(distance_to_other, distance_limit);
        FireBullet();
    }
    //Option Moving Funtion
    public void MovingOption(float distance, float limit)
    {
        if (distance > limit)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (transform.position.x < 9.25)
                    transform.Translate(speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.position.x > -9.25f)
                    transform.Translate(-speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (transform.position.y < 4.77f)
                    transform.Translate(0, speed, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (transform.position.y > -4.77f)
                    transform.Translate(0, -speed, 0);
            }
        }
    }

    //Player Can Fire Bullet
    void FireBullet()
    {
        if (Input.GetKey(KeyCode.Z) && this.delta > this.delay)
        {
            this.delta = 0;
            Instantiate(bullet_prefab);
        }
    }
}

