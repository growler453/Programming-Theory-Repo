using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float health {get; set;}
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        health = 3;
    }

    private void Update()
    {
        if (GameManager.gameActive == true)
        {
            // Move around
        }
        else
            health = 3;

        if (health <= 0)
        {
            gameManager.EndGame();
        }

        health -= 0.1f * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Deactivate object and add or remove health
    }
}
