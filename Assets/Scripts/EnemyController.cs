using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 1f;
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    protected Vector2 movement;
    protected float timeLeft;
    protected Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Horizontal"))
        {

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1);

        }

        if (collision.CompareTag("Vertical"))
        {

            rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);

        }
    }

    public void SpawnEnemies()
    {

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

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(gameObject, spawnPosition, Quaternion.identity);

    }

    protected  void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rb.AddForce(movement * maxSpeed);

    }

}
