using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVariantController : EnemyController
{

    public PlayerController playerInfo;

   

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

    void HalfTheirSize()
    {

        transform.localScale = new Vector2(0.5f, 0.5f);

        Invoke("ReturnTheirSize", 10f);

    }

    void ReturnTheirSize()
    {

        transform.localScale = new Vector2(1f, 1f);

    }
}
