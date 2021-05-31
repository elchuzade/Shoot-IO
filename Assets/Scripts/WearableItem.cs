using System.Collections;
using UnityEngine;
using static GlobalVariables;

public class WearableItem : MonoBehaviour
{
    public Wearables itemName;

    // Later this can be an array of particles instead of just a single particle
    // Each particle would end up having its own time to run
    public GameObject effectParticles;


    public void RunIdleAnimation()
    {
        if (itemName == Wearables.Cigar)
        {
            // This will trigger the chain of events. Time for fire particles to light and dim should be adjusted
            transform.Find("Zippo").GetComponent<AnimationTrigger>().Trigger("Appear");
            StartCoroutine(StartParticles());
        }
    }

    IEnumerator StartParticles()
    {
        yield return new WaitForSeconds(2);

        effectParticles.SetActive(true);

        StartCoroutine(StopParticles());
    }

    IEnumerator StopParticles()
    {
        yield return new WaitForSeconds(2);

        effectParticles.SetActive(false);
    }
}
