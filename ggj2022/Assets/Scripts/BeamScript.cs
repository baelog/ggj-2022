using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float waitTime = 2.0f;
    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Destroy(gameObject);
        }

    }
}
