using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Script : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid2D;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();

        this.player = GameObject.Find("Player");
        Vector3 playerPos = this.player.transform.position;
        transform.position = playerPos;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -5.5f)
            Destroy(gameObject);

        this.rigid2D.AddForce(transform.up * 2.0f);
        this.rigid2D.AddForce(transform.right * 3.0f);
    }
}
