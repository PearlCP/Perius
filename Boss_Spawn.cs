using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_Spawn : MonoBehaviour
{
    public GameObject Boss_1;
    public GameObject Boss_2;
    public GameObject Boss_3;
    public GameObject BossEffect;
    public float spawn_delay = 75.0f;

    public bool spawn_boss = true; //if false, this object don't spawn boss
    float time;
    public int boss_type;

    // Update is called once per frame
    void Update()
    {
        if (spawn_boss)
            time += Time.deltaTime;

        if (time >= spawn_delay && spawn_boss)
        {
            if (Random.Range(0, 0) == 0) //chance of spawning bos is 33%
            {
                spawn_boss = false;
                if (Random.Range(1, 4) == 1)
                {
                    boss_type = 1;
                    Instantiate(Boss_1);
                }

                else if (Random.Range(1, 3) == 1)
                {
                    boss_type = 2;
                    Instantiate(Boss_2);
                }
                else
                {
                    boss_type = 3;
                    Instantiate(Boss_3);
                }
                Instantiate(BossEffect);
                time = 0;
            }
            else
            {
                time -= 20.0f;
            }
                
        }
    }
}
