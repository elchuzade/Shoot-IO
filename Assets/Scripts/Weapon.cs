using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool targetLocked;
    public GameObject lockedTarget;

    [SerializeField] Transform weaponTip;
    [SerializeField] GameObject bullet;
    // Where bullet case will fly out
    [SerializeField] GameObject bolt;

    float fireRate = 0.1f;
    float time = 0;

    #region Public Methods
    // Repetitive function gets called inside update method
    public void Turn(Vector3 direction)
    {
        if (targetLocked)
        {
            // Aim at target and shoot
            Vector3 directionToClosestEnemy = lockedTarget.transform.position - transform.position;
            float angle = Mathf.Atan2(directionToClosestEnemy.z, directionToClosestEnemy.x) * Mathf.Rad2Deg;

            transform.parent.localRotation = Quaternion.Euler(0, 90 - angle, 0);

            Shoot();
        } else
        {
            bolt.SetActive(false);
            // Follow mouse direction
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

            transform.parent.localRotation = Quaternion.Euler(0, 90 - angle, 0);
        }
    }
    #endregion

    #region Private Methods
    // Repetitive function gets called inside update method
    void Shoot()
    {
        if (time >= fireRate)
        {
            bolt.SetActive(true);
            Instantiate(bullet, weaponTip.position, weaponTip.rotation);
            time = 0;
        } else
        {
            time += Time.deltaTime;
        }
    }
    #endregion
}
