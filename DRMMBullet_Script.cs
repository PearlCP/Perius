using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DRMMBullet_Script : MonoBehaviour
{
    GameObject Dormmamu;
    GameObject Player;

    float speed = 0.2f;

    void Start()
    {
        this.Dormmamu = GameObject.Find("Dormmamu(Clone)");
        this.Player = GameObject.Find("Player");

        Vector2 newPos = Player.transform.position - gameObject.transform.position; //Player와 자신의 거리 측정
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg; //arctan y / x (Rad2Deg >> 라디안을 각도로)
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        Vector3 spawnPos = this.Dormmamu.transform.position;
        transform.position = new Vector3(spawnPos.x - 0.4f, spawnPos.y + 0.5f, spawnPos.z);
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
        if (other.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }
    }
}
