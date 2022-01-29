using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeplacement : MonoBehaviour
{
    MonsterStats statsScript;
    // Start is called before the first frame update
    void Start()
    {
        statsScript = this.GetComponent<MonsterStats>();
    }
    // Update is called once per frame
    void Update()
    {
        statsScript.hp -= 1;
    }

    void OnCollisionEnter(Collision collision)
    {
        print("toucher");
            if(collision.gameObject.tag == "Floor")
                print("je suis au sol");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        print("ratté");
        if(col.gameObject.tag == "Floor") {
            print("je suis pas au sol");
            gameObject.GetComponent<MonsterStats>().hp -= statsScript.damage;
        }
    }
     
}
