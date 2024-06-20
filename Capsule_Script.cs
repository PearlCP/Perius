using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Capsule_Script : MonoBehaviour
{
    GameObject spawner;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.spawner = GameObject.Find("CapsuleSpawn");
        Vector3 spawnPos = this.spawner.transform.position;
        transform.position = spawnPos;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
        speed -= 0.003f;
    }
}
