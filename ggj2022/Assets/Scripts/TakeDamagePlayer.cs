using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TakeDamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Character2DControler stats;
    public Animator animator;
    public void ReduceHealthPlayer(int value)
    {
        stats.health -= value;

        if (stats.health <= 0)
        {
            stats.health = 10;
            stats.death = true;
            animator.SetBool("Death", true);
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("Level1");
    }
}
