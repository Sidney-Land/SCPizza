using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // integer used for the left mouse button
    private const int LEFT_MOUSE = 0;

    // Magnitude of Player's velocity in units per second
    public float moveSpeed;

    // Direction of Player's velocity
    private Vector2 moveDirection = new Vector2();

    // Reference to rigidbody for movement
    public Rigidbody2D rb;

    public Transform pizzaPlatter;

    // Pizza to be thrown
    public GameObject cheesePizza; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Upon click
        if (Input.GetMouseButtonDown(LEFT_MOUSE))
        {
            // Get where Player clicked in world coordinates
            Vector2 tossPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Get the direction pizza will fly towards to determine its rotation
            Vector2 tossDirection = (tossPos - (Vector2)transform.position).normalized;
            Quaternion tossRotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(Vector2.up, tossDirection));

            // Create pizza
            Instantiate(cheesePizza, pizzaPlatter.position, tossRotation);
        }
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        // Get movement input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Change Player's velocity
        rb.velocity = moveSpeed * moveDirection;
    }
}
