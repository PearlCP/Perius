using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barrier_Script : MonoBehaviour
{
    GameObject player;
    GameObject status;

    float playerPos;
    float barrierTime;
    void Start()
    {
        this.player = GameObject.Find("Player");
        this.status = GameObject.Find("StatusBar");
    }

    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = playerPos;
        barrierTime = status.GetComponent<Status_Script>().statusArray[5];

        if (barrierTime <= 0)
            gameObject.SetActive(false);
    }

}
