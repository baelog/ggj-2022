using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public MonsterStats stats;
    public GameObject objToDestroy;
    public void ReduceHealth(int value)
    {
        stats.hp -= value;
        //annimation possible
        if (stats.hp <= 0)
            Destroy(objToDestroy);
    }
}
