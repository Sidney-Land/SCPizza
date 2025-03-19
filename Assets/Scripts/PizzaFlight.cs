using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaFlight : MonoBehaviour
{
    // Speed pizza flies forward
    public float flightSpeed;

    // Boundaries for pizzas, immediately return to pool when they are exceeded
    public float xBound;
    public float yBound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Fly forward at flightSpeed, Vector2.up is where the pizza points unrotated
        transform.Translate(flightSpeed * Time.deltaTime * Vector2.up);

        // Deactivate slice if outside of boundary
        if (transform.position.x > xBound || transform.position.x < -xBound || transform.position.y > yBound || transform.position.y < -yBound)
        {
            gameObject.SetActive(false);
        }
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pizza has been sent to a patron
        if (collision.CompareTag("Characters"))
        {
            gameObject.SetActive(false);
        }
    }
}
