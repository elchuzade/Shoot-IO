using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;

public class Platform : MonoBehaviour
{
    public Vector3 position;
    public Vector3 rotation;
    public PlatformTypes platformType;
    public List<Building> buildings = new List<Building>();
    public List<Tower> towers = new List<Tower>();
    public List<Wall> walls = new List<Wall>();
    public List<Gate> gates = new List<Gate>();

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
