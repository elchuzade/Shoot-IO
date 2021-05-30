using System.Collections.Generic;
using UnityEngine;

public class DetectArea : MonoBehaviour
{
    List<GameObject> lockedTargets = new List<GameObject>();
    [SerializeField] Weapon weapon;

    void Update()
    {
        if (lockedTargets.Count > 0)
        {
            weapon.lockedTarget = GetClosestLockedTarget();
            weapon.targetLocked = true;
        } else
        {
            weapon.lockedTarget = null;
            weapon.targetLocked = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Body")
        {
            Debug.Log(other.gameObject.transform.position);
            lockedTargets.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Body")
        {
            lockedTargets.Remove(other.gameObject);
        }
    }

    GameObject GetClosestLockedTarget()
    {
        GameObject closestTarget = lockedTargets[0];
        float targetDistance = Vector3.Distance(closestTarget.transform.position, transform.position);

        for (int i = 0; i < lockedTargets.Count; i++)
        {
            if (Vector3.Distance(lockedTargets[i].transform.position, transform.position) < targetDistance)
            {
                targetDistance = Vector3.Distance(lockedTargets[i].transform.position, transform.position);
            }
        }

        return closestTarget;
    }
}
