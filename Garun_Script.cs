using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Garun_Script : MonoBehaviour
{
    GameObject spawner;
    GameObject status;
    public GameObject effect;
    public AudioClip DamagedSE;
    new AudioSource audio;

    public float speed = -0.15f;
    public int hp;
    float lifeTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.audio = GetComponent<AudioSource>();
        this.spawner = GameObject.Find("GarunSpawn");
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
            hp -= (int)status.GetComponent<Status_Script>().statusArray[3];
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
        transform.Rotate(0, 0, 0.5f);
        this.lifeTime += Time.deltaTime;
        if (lifeTime >= 10 || hp <= 0)
            Destroy(gameObject);
    }
}
