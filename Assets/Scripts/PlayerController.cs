using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public delegate void MultiDelegate();
    public MultiDelegate powerUpMultiDelegate;


    public float speed = 2;
    private float horizontal;
    private float vertical;
    private Rigidbody2D rb;

    public ObjectiveController starterObjective;
    public EnemyController enemies;
    public EnemyVariantController variantEnemies;
    public Power_Up_Controller powerUp;


    public int enemyDecider;

    Animator animator;

    public Canvas canvas;

    public float timeInBetweenScenes = 30f;



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(canvas);
        
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        starterObjective.SpawnObjects();
        animator = GetComponent<Animator>();

        

        Invoke("SkipSceneController", timeInBetweenScenes);


        powerUp.SpawnPowerUpTimer();

        

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
        SkipScenetoThree();
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

            Score_Manager.IncreaseScore();





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

         /*   if (Score_Manager.score > PlayerPrefs.GetInt("score"))
            {

                PlayerPrefs.SetInt("score", Score_Manager.score);

            } */


        }

        if (collision.CompareTag("PowerUp"))
        {

            if (powerUpMultiDelegate != null)
            {
                powerUpMultiDelegate();
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
           /* if (Score_Manager.score > PlayerPrefs.GetInt("score"))
            {

                PlayerPrefs.SetInt("score", Score_Manager.score);

            }*/
            animator.SetTrigger("Death");
            //Destroy(gameObject);


        }
    }

    public void SkipScenetoOne()
    {

       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(canvas);
        SceneManager.LoadScene(1);
        Invoke("SkipSceneController", timeInBetweenScenes);



    }

    public void SkipScenetoTwo()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(2);
        Invoke("SkipSceneController", timeInBetweenScenes);


        float spawnY = Random.Range(-4f, 2.75f);
        float spawnX = Random.Range(-9f, 9f);

        while (spawnX >= -1.9 && spawnX <= 1.9)
        {
            spawnX = Random.Range(-9f, 9f);
        }

        while (spawnY >= -2.4 && spawnY <= 1.1)
        {
            spawnY = Random.Range(-4f, 2.75f);
        }

        powerUp.Invoke("SpawnPowerUpTimer", 0f);
    }

    public void SkipScenetoThree()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(3);

        Destroy(gameObject);


    }

    public void SkipSceneController()
    {

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            SkipScenetoTwo();
        }

        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SkipScenetoThree();
        }


    }

}

