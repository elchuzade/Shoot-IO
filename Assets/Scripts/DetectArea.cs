using System.Collections.Generic;
using UnityEngine;

public class DetectArea : MonoBehaviour
{
    List<GameObject> lockedTargets = new List<GameObject>();
    [SerializeField] Target target;

    // To not aim at others
    [SerializeField] bool me;

    void Update()
    {
        if (lockedTargets.Count > 0)
        {
            target.lockedTarget = GetClosestLockedTarget();
            target.targetLocked = true;
        }
        else
        {
            if (target)
            {
                target.lockedTarget = null;
                target.targetLocked = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Me" && !me || other.gameObject.tag == "Mob" && me)
        {
            lockedTargets.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Me" && !me || other.gameObject.tag == "Mob" && me)
        {
            lockedTargets.Remove(other.gameObject);
        }
    }

    GameObject GetClosestLockedTarget()
    {
        GameObject closestTarget = lockedTargets[0];
        if (closestTarget != null)
        {
            float targetDistance = Vector3.Distance(closestTarget.transform.position, transform.position);
            for (int i = 0; i < lockedTargets.Count; i++)
            {
                if (lockedTargets[i] != null && Vector3.Distance(lockedTargets[i].transform.position, transform.position) < targetDistance)
                {
                    targetDistance = Vector3.Distance(lockedTargets[i].transform.position, transform.position);
                }
            }
            return closestTarget;
        } else
        {
            lockedTargets.RemoveAt(0);
        }
        return null;
    }
}
