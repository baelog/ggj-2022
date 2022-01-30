using UnityEngine;
using System;
using UnityEngine.SceneManagement;





public class Character2DControler : MonoBehaviour
{
    public float MovementSpeed = 4;
    public float JumpForce = 4;
    public int health = 10;
    private int jump = 0;
    public bool death = false;
    private int transformation = 1;
    private Rigidbody2D _rigidbody;
    public Animator animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");

        if (death == false)
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        }

        animator.SetFloat("Speed", Mathf.Abs(movement));

        if (Input.GetKeyUp("e") && death == false)
        {
            if (transformation == 1)
            {
                transformation = 2;
                animator.SetBool("Transformation", true);
            }
            else
            {
                transformation = 1;
                animator.SetBool("Transformation", false);
            }
        }

        if (!Mathf.Approximately(0, movement) && death == false)
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        //if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)

        if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            jump = 0;

        if (Input.GetButtonDown("Jump") && jump < transformation && death == false)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            jump += 1;
        }


    }

    public void Die()
    {
        SceneManager.LoadScene("Level1");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TP"))
        {
            transform.position = new Vector3(GameObject.Find("TpSky").transform.position.x, GameObject.Find("TpSky").transform.position.y, 0);
            print("TP");
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            health = 10;
            death = true;
            animator.SetBool("Death", true);
        }
    }
}
