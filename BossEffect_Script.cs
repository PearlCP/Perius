using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossEffect_Script : MonoBehaviour
{
    GameObject BossSpawn;

    public AudioClip EffectSE1;
    public AudioClip EffectSE2;

    float BossPos;
    int findBossType;

    new AudioSource audio;
    void Start()
    {
        this.BossSpawn = GameObject.Find("BossSpawn");
        findBossType = BossSpawn.GetComponent<Boss_Spawn>().boss_type;

        switch (findBossType)
        {
            case 1:
                this.BossSpawn = GameObject.Find("Alice(Clone)");
                break;
            case 2:
                this.BossSpawn = GameObject.Find("Dormmamu(Clone)");
                break;
            case 3:
                this.BossSpawn = GameObject.Find("Minagi(Clone)");
                break;
        }
        Vector3 BossPos = this.BossSpawn.transform.position;
        gameObject.transform.position = new Vector3 (BossPos.x, BossPos.y + 0.7f, BossPos.z);

        this.audio = GetComponent<AudioSource>();
        this.audio.PlayOneShot(this.EffectSE1);
        this.audio.PlayOneShot(this.EffectSE2);

        transform.localScale = new Vector3(2, 2, 1);
    }

    void Update()
    {
        StartCoroutine(disable());
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
