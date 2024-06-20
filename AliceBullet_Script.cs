using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceBullet_Script : MonoBehaviour
{
    GameObject Alice;
    float speed = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        this.Alice = GameObject.Find("Alice(Clone)");
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(60, 120));
        Vector3 spawnPos = this.Alice.transform.position;
        transform.position = new Vector3 (spawnPos.x - 0.4f, spawnPos.y + 0.5f, spawnPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed, 0);
        if (transform.position.x < -11)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }
    }
}
