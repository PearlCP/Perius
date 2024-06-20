using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Status_Script : MonoBehaviour
{
    public Sprite status0;
    public Sprite status1;
    public Sprite status2;
    public Sprite status3;    
    public Sprite status4;
    public Sprite status5;
    public Sprite status6;

    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;

    public GameObject EMP;
    public GameObject Barrier;

    Image current_img;

    GameObject player;

    public float[] statusArray = new float[6] { 0.05f, 0, 0, 1, 0, 0 }; //[0] = speed, [1] = missile, [2] = double, [3] = laser(Damage), [4] = option, [5] = invincible(???)
    int power;
    // Start is called before the first frame update
    void Start()
    {
        this.current_img = GetComponent<Image>();
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        power = player.GetComponent<Player_Controller>().capsule; //player로부터 capsule값 복사

        switch (power)
        {
            case 0:
                current_img.sprite = status0;
                break;
            //speed Up ON
            case 1:
                current_img.sprite = status1;
                if (Input.GetKey(KeyCode.X))
                {
                    if (statusArray[0] <= 0.15f) //maximum speed is 0.04
                        statusArray[0] += 0.02f;
                    player.GetComponent<Player_Controller>().capsule = 0;
                }
                break;
            //missile System ON
            case 2:
                current_img.sprite = status2;
                if (Input.GetKey(KeyCode.X))
                {
                    statusArray[1] = 1;
                    player.GetComponent<Player_Controller>().capsule = 0;
                }
                break;
            //double shot ON
            case 3:
                current_img.sprite = status3;
                if (Input.GetKey(KeyCode.X))
                {
                    statusArray[2] = 1;
                    player.GetComponent<Player_Controller>().capsule = 0;
                }
                break;
            //laser shot ON
            case 4:
                current_img.sprite = status4;
                if (Input.GetKey(KeyCode.X))
                {
                    statusArray[3] = 2;
                    player.GetComponent<Player_Controller>().capsule = 0;
                }
                break;
            //option ON
            case 5:
                current_img.sprite = status5;
                if (Input.GetKey(KeyCode.X))
                {
                    if (statusArray[4] <= 2) //maximum option is 3
                        statusArray[4] += 1;
                    switch (statusArray[4])
                    {
                        case 1:
                            Option1.SetActive(true);
                            break;
                        case 2:
                            Option2.SetActive(true);
                            break;
                        case 3:
                            Option3.SetActive(true);
                            break;
                        default:
                            player.GetComponent<Player_Controller>().capsule = 0; 
                            break;
                    }
                    player.GetComponent<Player_Controller>().capsule = 0;
                }
                break;
            //invincible ON
            case 6:
                current_img.sprite = status6;
                if (Input.GetKey(KeyCode.X))
                {
                    player.GetComponent<Player_Controller>().capsule = 0;
                    statusArray[5] = 10;
                    Instantiate(EMP);
                    Barrier.SetActive(true);
                }
                break;
            default: break;
        }
        if (statusArray[5] > 0)
        {
            statusArray[5] -= Time.deltaTime;
            if (statusArray[5] < 0)
                statusArray[5] = 0;
        }
    }
}
