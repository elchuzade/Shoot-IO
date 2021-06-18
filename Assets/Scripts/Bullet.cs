using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 0.5f;
    public int damage = 2;

    void Start()
    {
        StartCoroutine(Disappear());
    }

    void Update()
    {
        transform.position += transform.forward * bulletSpeed;
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Mob")
        {
            other.gameObject.GetComponent<Mob>().DealDamage(damage);
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Me")
        {
            other.gameObject.transform.Find("Character").GetComponent<PlayerController>().DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
