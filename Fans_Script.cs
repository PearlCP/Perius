using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Fans_Script : MonoBehaviour
{
    GameObject spawner;
    GameObject status;
    public GameObject effect;
    public AudioClip DamagedSE;
    new AudioSource audio;

    public float speed = -0.07f;
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        this.audio = GetComponent<AudioSource>();
        this.spawner = GameObject.Find("FansSpawn");
        this.status = GameObject.Find("StatusBar");
        Vector3 spawnPos = this.spawner.transform.position;
        transform.position = spawnPos;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Instantiate(effect);
            this.audio.PlayOneShot(this.DamagedSE);
            hp -= (int)status.GetComponent<Status_Script>().statusArray[3]; //1 for bullets, 2 for laser
        }
        if (other.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
        if (this.transform.position.x < -11)
            transform.position = new Vector3(11, this.transform.position.y, this.transform.position.z);
        if (hp <= 0)
            Destroy(gameObject);
    }
}
