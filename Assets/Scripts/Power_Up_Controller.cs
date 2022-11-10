using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Up_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Invoke("SpawnPowerUpTimer", 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            Destroy(gameObject);

        }

    }


    void SpawnPowerUp()
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

    public void SpawnPowerUpTimer()
    {

        Invoke("SpawnPowerUp", 10f);

    }
}
