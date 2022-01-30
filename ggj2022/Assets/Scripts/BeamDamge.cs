using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamDamge : MonoBehaviour
{
    // Start is called before the first frame update
    public MonsterStats stats;
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        print("ratté");
        if(col.gameObject.tag == "Player") {
            TakeDamagePlayer dealDamage = col.gameObject.GetComponent<TakeDamagePlayer>();
            dealDamage.ReduceHealthPlayer(stats.damage);
        }
    }
}
