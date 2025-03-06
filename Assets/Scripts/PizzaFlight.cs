using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaFlight : MonoBehaviour
{
    public float flightSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(flightSpeed * Time.deltaTime * Vector2.up);

    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Characters"))
        {
            Destroy(gameObject);
        }
    }


}
