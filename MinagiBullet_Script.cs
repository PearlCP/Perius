using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinagiBullet_Script : MonoBehaviour
{
    GameObject Minagi;
    GameObject Player;

    float speed = 0.2f;

    void Start()
    {
        this.Minagi = GameObject.Find("Minagi(Clone)");
        this.Player = GameObject.Find("Player");

        Vector2 newPos = Player.transform.position - gameObject.transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        Vector3 spawnPos = this.Minagi.transform.position;
        transform.position = new Vector3(spawnPos.x - 0.4f, spawnPos.y + Random.Range(-0.3f, 0.3f), spawnPos.z);

        float random_scale = Random.Range(-4.0f, 4.0f);
        transform.localScale = new Vector3(random_scale, random_scale, random_scale);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
        if (transform.position.x < -11)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Barrier" || other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
