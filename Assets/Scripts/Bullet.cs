using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 0.5f;

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
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barrier" || other.gameObject.tag == "Ball")
        Destroy(gameObject);
    }
}
