using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVariantController : EnemyController
{

    public PlayerController playerInfo;

    // Start is called before the first frame update
    void Start()
    {

 

    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var target = GameObject.FindWithTag("Player").transform;

        if (collision.gameObject.CompareTag("Horizontal") || collision.gameObject.CompareTag("Vertical"))
        {

            rb.velocity = new Vector2((target.position.x - rb.position.x), (target.position.y - rb.position.y));

        }
    }
}
