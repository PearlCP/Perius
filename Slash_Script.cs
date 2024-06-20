using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash_Script : MonoBehaviour
{
    GameObject player;

    float playerPos;
    void Start()
    {
        this.player = GameObject.Find("Player");
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3 (playerPos.x + Random.Range(-1.0f, 1.0f), playerPos.y + Random.Range(-1.0f, 1.0f), playerPos.z);
    }

    void Update()
    {
        StartCoroutine(disable());
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
