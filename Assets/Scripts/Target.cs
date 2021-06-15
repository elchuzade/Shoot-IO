using UnityEngine;

public class Target : MonoBehaviour
{
    // To have something to aim at
    public GameObject lockedTarget;
    public bool targetLocked;

    bool weaponRotated = false;

    [SerializeField] GameObject rightArm;

    Weapon weapon;

    void Start()
    {
        weapon = rightArm.transform.GetChild(0).GetComponent<Weapon>();
    }

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
            if (lockedTarget != null)
            {
                transform.LookAt(lockedTarget.transform);
                weapon.Shoot();
            }
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
