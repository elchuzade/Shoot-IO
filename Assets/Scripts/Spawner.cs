using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject spawnerPrefab;
    [SerializeField] float respawnTime;
    [SerializeField] int maxNumber;
    [SerializeField] float spawnRadius;
    [SerializeField] List<GameObject> mobs = new List<GameObject>();

    float time = 0;

    void Start()
    {
        InstantiateMobs();
    }

    void Update()
    {
        if (mobs.Count < maxNumber)
        {
            if (time >= respawnTime)
            {
                time = 0;
                InstantiateMobs();
            } else
            {
                time += Time.deltaTime;
            }
        }
    }

    void InstantiateMobs()
    {
        Vector2 pos = Random.insideUnitCircle;
        pos = pos.normalized * Random.Range(0, spawnRadius);

        // 0.75 is half of the height of an emoji
        Vector3 randomPosition = new Vector3(pos.x, 0.75f, pos.y);

        GameObject mob = Instantiate(spawnerPrefab, transform.position + randomPosition, Quaternion.identity);
        mob.transform.SetParent(transform);
        mob.transform.Find("Mob").GetComponent<Mob>().spawnerPosition = transform.position;

        mobs.Add(mob);
    }
}
