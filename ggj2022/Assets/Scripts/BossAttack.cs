using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform leftTop;
    public Transform rightBot;
    public GameObject beam;
    private float waitTime = 0.5f;
    private float timer = 0.0f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            timer = 0;
            Instantiate(beam, new Vector3(Random.Range(leftTop.position.x, rightBot.position.x), Random.Range(leftTop.position.y, rightBot.position.y), leftTop.position.z), transform.rotation * Quaternion.Euler(0f,180f, 0f));
        }
    }
}
