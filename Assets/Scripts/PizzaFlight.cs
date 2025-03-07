using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaFlight : MonoBehaviour
{
    // Speed pizza flies forward
    public float flightSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Fly forward at flightSpeed, Vector2.up is where the pizza points
        transform.Translate(flightSpeed * Time.deltaTime * Vector2.up);
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pizza has been sent to a patron
        if (collision.CompareTag("Characters"))
        {
            Destroy(gameObject);
        }
    }
}
