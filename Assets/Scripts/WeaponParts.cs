using UnityEngine;
using static GlobalVariables;

public class WeaponParts : MonoBehaviour
{
    public Weapons weaponName;
    public float baseFireRate;

    public Transform barrelTip;
    public GameObject bullet;
    // Where bullet case will fly out
    public ParticleSystem tipFire;
    public ParticleSystem bolt;

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
}
