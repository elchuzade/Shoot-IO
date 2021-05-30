using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool targetLocked;
    public GameObject lockedTarget;

    Transform barrelTip;
    GameObject bullet;
    // Where bullet case will fly out

    float fireRate;
    float time = 0;

    [SerializeField] GameObject rifle;
    [SerializeField] GameObject sniper;
    [SerializeField] Transform rightArm;

    GameObject myWeapon;

    void Start()
    {
        myWeapon = Instantiate(rifle, rightArm.position, Quaternion.identity);
        myWeapon.transform.SetParent(rightArm);
        myWeapon.transform.localScale = Vector3.one;

        fireRate = myWeapon.GetComponent<WeaponParts>().baseFireRate;

        barrelTip = myWeapon.GetComponent<WeaponParts>().barrelTip;
        bullet = myWeapon.GetComponent<WeaponParts>().bullet;
    }

    #region Public Methods
    // Repetitive function gets called inside update method
    public void Turn(Vector3 direction)
    {
        if (targetLocked)
        {
            // Aim at target and shoot
            Vector3 directionToClosestEnemy = lockedTarget.transform.position - transform.position;
            float angle = Mathf.Atan2(directionToClosestEnemy.z, directionToClosestEnemy.x) * Mathf.Rad2Deg;

            transform.localRotation = Quaternion.Euler(0, 90 - angle, 0);

            Shoot();
        } else
        {
            // Follow mouse direction
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

            if (angle == 0)
            {
                transform.localRotation = Quaternion.Euler(0, angle, 0);
            } else
            {
                transform.localRotation = Quaternion.Euler(0, 90 - angle, 0);
            }
        }
    }
    #endregion

    #region Private Methods
    // Repetitive function gets called inside update method
    void Shoot()
    {
        if (time >= fireRate)
        {
            myWeapon.GetComponent<WeaponParts>().RunFireParticles();
            Instantiate(bullet, barrelTip.position, barrelTip.rotation);
            time = 0;
        } else
        {
            time += Time.deltaTime;
        }
    }
    #endregion
}
