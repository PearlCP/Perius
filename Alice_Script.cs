using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice_Script : MonoBehaviour
{
    public GameObject bullet;
    GameObject status;
    GameObject BossManagement;
    protected Animator animator;

    public AudioClip BulletSE1;
    public AudioClip BulletSE2;
    public AudioClip DamagedSE;
    public GameObject effect;
    new AudioSource audio;

    public int HP;

    float delay;
    bool attackable = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        this.audio = GetComponent<AudioSource>();
        this.status = GameObject.Find("StatusBar");
        this.BossManagement = GameObject.Find("BossSpawn");
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (attackable)
            delay += Time.deltaTime;

        if (delay > 6.0f && attackable)
        {
            attackable = false;
            if (Random.Range(0, 1) == 0)
            {
                attackable = false;
                transform.position = new Vector3(Random.Range(7.0f, 9.0f), Random.Range(-3.0f, 3.0f), gameObject.transform.position.z);
                animator.SetBool("Battack", true);
                StartCoroutine(Attack1(Random.Range(4, 7)));
                delay = 0;
            }
            /*
            else
            {
                attackable = false;
                animator.SetBool("Bwalk", true);
                StartCoroutine(Attack2());
                delay = 0;
            }
            */
        }

        if (HP <= 0)
        {
            Instantiate(effect);
            Destroy(gameObject);
            BossManagement.GetComponent<Boss_Spawn>().spawn_boss = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            this.audio.PlayOneShot(this.DamagedSE);
            HP -= (int)status.GetComponent<Status_Script>().statusArray[3]; //1 for bullets, 2 for laser
        }
    }

    IEnumerator Attack1(int size)
    {   
        for (int j = 0; j < size; j++)
        {
            for (int i = 0; i < 3; i++)
                Instantiate(bullet);
            this.audio.PlayOneShot(this.BulletSE1);
            this.audio.PlayOneShot(this.BulletSE2);
            yield return new WaitForSeconds(0.5f);
        }
        animator.SetBool("Battack", false);
        attackable = true;
    }

    /*
    IEnumerator Attack2()
    {
        yield return new WaitForSeconds(0.3f);
        float speed = 0.15f;
        Vector3 spawnPos = this.player.transform.position;
        transform.position = new Vector3(gameObject.transform.position.x, spawnPos.y - 0.7f, gameObject.transform.position.z);
        for (int i = 0; i < 50; i++)
        {
            speed -= 0.02f;
            transform.Translate(speed, 0, 0);
            yield return new WaitForSeconds(0.02f);
        }
        speed = 0;
        yield return new WaitForSeconds(0.3f);
        transform.position = new Vector3(14, -0.7f, gameObject.transform.position.z);
        for (int i = 0; i < 15; i++)
        {
            speed -= 0.03f;
            transform.Translate(speed, 0, 0);
            yield return new WaitForSeconds(0.02f);
        }
        transform.position = new Vector3(7, gameObject.transform.position.y, gameObject.transform.position.z);
        animator.SetBool("Bwalk", false);
        attackable = true;
    }
    */
}
