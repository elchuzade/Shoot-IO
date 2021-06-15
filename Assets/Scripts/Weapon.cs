using UnityEngine;
using static GlobalVariables;

public class Weapon : MonoBehaviour
{
    public Weapons weaponName;
    public float baseFireRate;
    float shootTimer = 0;

    [SerializeField] Transform barrelTip;
    [SerializeField] GameObject bullet;
    // Where bullet case will fly out
    [SerializeField] ParticleSystem tipFire;
    [SerializeField] ParticleSystem bolt;


    #region Public Methods
    public void RunFireParticles()
    {
        // Run Bullet case falling
        bolt.Play();
        var boltEmission = bolt.emission;
        boltEmission.enabled = true;

        // Run fire from the barrel tip
        tipFire.Play();
        var timFireEmission = bolt.emission;
        timFireEmission.enabled = true;
    }

    public void MoveWeapon(Transform _transform)
    {
        // In city position and rotation and out city position and rotation
        transform.position = _transform.position;
        transform.rotation = _transform.rotation;
    }

    public void Shoot()
    {
        if (shootTimer >= baseFireRate)
        {
            Instantiate(bullet, barrelTip.position, barrelTip.rotation);
            RunFireParticles();
            shootTimer = 0;
        } else
        {
            shootTimer += Time.deltaTime;
        }
    }
    #endregion
}
