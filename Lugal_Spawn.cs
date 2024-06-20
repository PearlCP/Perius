using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lugal_Spawn : MonoBehaviour
{
    public GameObject Lugal;

    float Spawn_Delay = 0;

    float spawner_y;
    int spawn_max;

    public float Spawn_Delay_Min;
    public float Spawn_Delay_Max;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Spawn_Lugal();
    }


    //spawn Lugal(Enemy Spawn)
    void Spawn_Lugal()
    {
        Spawn_Delay += Time.deltaTime;
        if (Spawn_Delay > Random.Range(Spawn_Delay_Min, Spawn_Delay_Max))
        {
            spawner_y = Random.Range(-4.8f, 4.8f);
            spawn_max = Random.Range(2, 6);
            transform.position = new Vector3(11, spawner_y, this.transform.position.z);
            StartCoroutine(SpawnLoopFans((int)spawn_max));
            Spawn_Delay = 0;
        }
    }

    IEnumerator SpawnLoopFans(int size)
    {
        for (int i = 0; i < size; i++)
        {
            Instantiate(Lugal);
            yield return new WaitForSeconds(0.08f);
        }
    }
}
