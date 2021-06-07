using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if player is inside the city
        if (other.gameObject.tag == "Me")
        {
            other.transform.Find("Character").GetComponent<Character>().EnterCity(gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if player is outside the city
        if (other.gameObject.tag == "Me")
        {
            other.transform.Find("Character").GetComponent<Character>().ExitCity(gameObject);
        }
    }
}
