using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerSight")
        {
            other.transform.parent.GetComponent<PlayerController>().SnapTower(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerSight")
        {
            other.transform.parent.GetComponent<PlayerController>().UnsnapTower(transform);
        }
    }
}
