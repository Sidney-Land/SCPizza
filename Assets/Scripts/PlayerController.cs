using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Magnitude of Player's velocity in units per second
    public float moveSpeed;

    // Direction of Player's velocity
    private Vector2 moveDirection = new Vector2();

    // Furthest distance away from Player camera can look
    public float lookDistance;

    // Reference to Pizza Platter where pizza is tossed
    public Transform pizzaPlatter;

    // Reference to (invisible) object controlling camera movment
    public Transform camCenter;

    // Pizza to be thrown
    public GameObject cheesePizza;

    // Reference to rigidbody for movement
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get where Player's mouse is (relative to transform.position) and direction in local coordinates
        Vector2 mouseRelPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;

        // Bind camera's center within the circle of radius lookDistance around Player (its local position relative to the Player)
        camCenter.localPosition = Vector2.ClampMagnitude(mouseRelPos, lookDistance);

        // Upon click, throw pizza
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Determine rotation of pizza 
            Quaternion tossRotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(Vector2.up, mouseRelPos.normalized));

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
