using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    GameObject Player;

    bool turn_angle = false;
    float timerToConfuse;
    void Start()
    {
        this.Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timerToConfuse = Player.GetComponent<Player_Controller>().confuse;

        if (timerToConfuse > 0) turn_angle = true;
        else turn_angle = false;

        if (turn_angle) transform.rotation = Quaternion.Euler(0, 0, 180);
        else transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
