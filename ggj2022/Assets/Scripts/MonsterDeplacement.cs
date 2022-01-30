using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeplacement : MonoBehaviour
{
    public MonsterStats statsScript;
    public Transform left;
    public Transform right;
    public SpriteRenderer sprite;
    public Transform attackPoint;
    int direction = 1;
    float distanceAttackPoint;
    // Start is called before the first frame update
    void Start()
    {
        distanceAttackPoint = attackPoint.transform.position.x - transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        float step = statsScript.speed * Time.deltaTime;
        if (direction == 1) {

            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, left.position, step);
            if (transform.position.x >= left.position.x - 0.1 && transform.position.x <= left.position.x + 0.1) {
                direction = 0;
                sprite.flipX = true;
                attackPoint.transform.position = new Vector3(attackPoint.transform.position.x - 2 * distanceAttackPoint, attackPoint.transform.position.y, attackPoint.transform.position.z);
            }
                
        } else {
            transform.position = Vector3.MoveTowards(transform.position, right.position, step);
            if (transform.position.x >= right.position.x - 0.1 && transform.position.x <= right.position.x + 0.1) {
                direction = 1;
                sprite.flipX = false;
                attackPoint.transform.Translate(Vector3.forward * 2 * distanceAttackPoint);
                attackPoint.transform.position = new Vector3(attackPoint.transform.position.x + 2 * distanceAttackPoint, attackPoint.transform.position.y, attackPoint.transform.position.z);

            }
        }
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
        }
    }

}
