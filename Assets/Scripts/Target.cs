using UnityEngine;

public class Target : MonoBehaviour
{
    // To have something to aim at
    public GameObject lockedTarget;
    public bool targetLocked;

    bool weaponRotated = false;

    [SerializeField] GameObject rightArm;

    void Update()
    {
        if (targetLocked)
        {
            if (!weaponRotated)
            {
                // This is to rotate the weapon to the body of a target
                rightArm.transform.Rotate(Vector3.up, -9);
                weaponRotated = true;
            }
            transform.LookAt(lockedTarget.transform);
        } else
        {
            if (weaponRotated)
            {
                // This is to rotate the weapon from the body of a target
                rightArm.transform.Rotate(Vector3.up, 9);
                weaponRotated = false;
            }
        }
    }
}
