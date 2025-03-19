using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPool : MonoBehaviour
{
    // Pizza to be placed on the Platter and used to populate the pizzaPool
    public GameObject pizzaPrefab;

    // Pool of pizza
    private List<GameObject> pizzaPool;

    // How many slices are on a single pizza
    public int sliceAmount;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Declare pizzaPool
        pizzaPool = new List<GameObject>();

        // Fill pizzaPool with pizza objects
        for (int i = 0; i < sliceAmount; i++)
        {
            GameObject tempObj = Instantiate(pizzaPrefab);
            pizzaPool.Add(tempObj);
            tempObj.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Takes a pizza slice out of the PizzaPool,
    // and places it at tossPos (world coords) and rotates it by tossRotation (no rotation points slice upwards)
    public GameObject SpawnPizza(Vector2 tossPos, Quaternion tossRotation)
    {
        // Iterate through pizzaPool
        foreach (GameObject slice in pizzaPool)
        {
            // If a pizza slice is available in pizzaPool
            if (!slice.activeSelf)
            {
                // Activate, position, and rotate pizza slice
                slice.SetActive(true);
                slice.transform.position = tossPos;
                slice.transform.rotation = tossRotation;

                // return pizza slice, and end loop
                return slice;
            }
        } 
        
        // If no pizza available, return null
        return null;
    }
}
