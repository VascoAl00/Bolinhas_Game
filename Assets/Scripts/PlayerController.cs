using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;
    private float horizontal;
    private float vertical;
    private Rigidbody2D rb;
    public Text scoretext;
    private int score;

    public ObjectiveController starterObjective;
    public EnemyController enemies;
    public EnemyVariantController variantEnemies;


    public int enemyDecider;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        starterObjective.SpawnObjects();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        enemyDecider = Random.Range(1, 3);
        
    }

    void Death()
    {

        Destroy(gameObject);

    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x = pos.x + horizontal * speed * Time.deltaTime;
        pos.y = pos.y + vertical * speed * Time.deltaTime;
        rb.MovePosition(pos);

        animator.SetFloat("Velocity", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Objective"))
        {

            score++;
            scoretext.text = "Score: " + score;




            if ( enemyDecider == 1)
            {

                variantEnemies.SpawnEnemies();

            } 

            else
            {

                enemies.SpawnEnemies();

            }

        }

        if (collision.CompareTag("Enemy"))
        {
            animator.SetTrigger("Death");
            //Destroy(gameObject);

        }

    }
}
