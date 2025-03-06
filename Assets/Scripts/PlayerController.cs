using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int LEFT_MOUSE = 0;

    public float moveSpeed;

    private Vector2 moveDirection = new Vector2();

    public Rigidbody2D rb;

    public GameObject cheesePizza; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(LEFT_MOUSE))
        {
            Vector2 tossPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 tossDirection = (tossPos - (Vector2)transform.position).normalized;

            Quaternion tossRotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(Vector2.up, tossDirection));

            Instantiate(cheesePizza, tossPos, tossRotation);
        }
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        rb.velocity = moveSpeed * moveDirection;
    }


}
