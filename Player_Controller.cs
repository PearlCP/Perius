using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    GameObject status;

    protected Animator animator;

    public GameObject bullet_prefab;
    public GameObject bullet2_prefab;
    public GameObject missile_prefab;

    public AudioClip FireSE;
    public AudioClip DeadSE;
    public AudioClip HealSE;
    public AudioClip ConfuseSE;

    public float speed = 0.07f;
    public int capsule = 0;
    public float confuse = 0;

    float delta = 0;
    float delay = 0.09f;

    float missile_delta = 0;
    float missile_delay = 1.0f;
    float usedMissile = 0;
    float doubleShot = 0;
    public int fireSecondShot = 0;

    bool alive = true;
    new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        this.audio = GetComponent<AudioSource>();
        this.status = GameObject.Find("StatusBar");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            alive = false;
            animator.SetBool("Bdead", true);
            this.audio.PlayOneShot(this.DeadSE);
            StartCoroutine(ExitToTitle());
        }
        if (other.gameObject.tag == "Capsule")
        {
            this.audio.PlayOneShot(this.HealSE);
            if (capsule < 6)
                capsule += 1;
        }
        if (other.gameObject.tag == "Bubble")
        {
            this.audio.PlayOneShot(this.ConfuseSE);
            confuse = 5.0f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (confuse > 0)
            this.confuse -= Time.deltaTime;
        this.missile_delta += Time.deltaTime;
        speed = status.GetComponent<Status_Script>().statusArray[0];
        usedMissile = status.GetComponent<Status_Script>().statusArray[1];
        doubleShot = status.GetComponent<Status_Script>().statusArray[2];

        if (alive)
        {
            MovingPlayer();
            FireBullet();
            FireMissile();
        }
    }

    //Player Moving Funtion
    void MovingPlayer()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < 9.25)
                transform.Translate(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -9.25f)
                transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SetMyBool(true, false, false);
            if (transform.position.y < 4.77f)
                transform.Translate(0, speed, 0);
        }
        else if (!Input.GetKey(KeyCode.DownArrow))
        {
            SetMyBool(false, false, true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SetMyBool(false, true, false);
            if (transform.position.y > -4.77f)
                transform.Translate(0, -speed, 0);
        }
        else if (!Input.GetKey(KeyCode.UpArrow))
        {
            SetMyBool(false, false, true);
        }
    }

    //Player Can Fire Bullet
    void FireBullet()
    {
        if (Input.GetKey(KeyCode.Z) && this.delta > this.delay)
        {
            this.delta = 0;
            if (doubleShot == 1)
            {
                Instantiate(bullet_prefab);
                Instantiate(bullet2_prefab);
            }

            else
                Instantiate(bullet_prefab);
            this.audio.PlayOneShot(this.FireSE);
            fireSecondShot = 0;
        }
    }

    void FireMissile()
    {
        if (usedMissile == 1 && this.missile_delta > this.missile_delay)
        {
            this.missile_delta = 0;
            Instantiate(missile_prefab);
        }
    }

    void SetMyBool(bool a, bool b, bool c)
    {
        animator.SetBool("Btop", a);
        animator.SetBool("Bdown", b);
        animator.SetBool("Bfront", c);
    }

    IEnumerator ExitToTitle()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("GameOver");
    }
}