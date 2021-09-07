using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static float health { get; private set; }
    private Material playerColor;
    private GameManager gameManager;
    [SerializeField] Slider healthBar;
    private float horizontalInput;
    private float verticalInput;
    private float momementRange = 10.0f;
    private float speed;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerColor = GetComponent<Renderer>().sharedMaterial;
        playerColor.color = MainManager.Instance.pickedColor;
        health = 3;
        speed = 15.0f;
    }

    private void Update()
    {
        if (GameManager.gameActive)
        {
            // Decrease health over time
            health -= 0.25f * Time.deltaTime;
            healthBar.value = health;

            // Decrease speed over time if higher than 20
            if (speed > 15.0f) { speed -= 0.1f; }

            // Keep within movement range bounds
            KeepInRange();

            // Get Player input for movement
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            // Player movement left to right
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            // Player movement forwards and backwards
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

            if (health <= 0f)
            {
                gameManager.EndGame();
            }
        }
    }

    private void KeepInRange()
    {
        if (transform.position.x < -momementRange)
            transform.position = new Vector3(-momementRange, transform.position.y, transform.position.z);
        if (transform.position.x > momementRange)
            transform.position = new Vector3(momementRange, transform.position.y, transform.position.z);

        if (transform.position.z < -momementRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, -momementRange);
        if (transform.position.z > momementRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, momementRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Disable candy on collision and give health/speed if good
        other.gameObject.SetActive(false);
        if (other.gameObject.CompareTag("Good"))
        {
            if (health < 3)
                health += 0.5f;

            if (speed < 25.0f)
            {
                speed += 1.0f;
            }
        } else
        if (other.gameObject.CompareTag("Bad"))
            health -= 0.1f;
    }

}
