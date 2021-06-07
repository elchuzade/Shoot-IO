using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            // Turn towards the player
            Debug.Log("Hi Player, I am shop keeper. What would you want to buy?");
        }
    }
}
