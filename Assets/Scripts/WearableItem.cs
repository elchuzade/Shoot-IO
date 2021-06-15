using System.Collections;
using UnityEngine;
using static GlobalVariables;

public class WearableItem : MonoBehaviour
{
    //public Wearables itemName;

    // Later this can be an array of particles instead of just a single particle
    // Each particle would end up having its own time to run
    public GameObject effectParticles;

    #region Public Methods
    public void RunIdleAnimation()
    {
        //    if (itemName == Wearables.Cigar)
        //    {
        //        // This will trigger the chain of events. Time for fire particles to light and dim should be adjusted
        //        transform.Find("Zippo").GetComponent<AnimationTrigger>().Trigger("Appear");
        //        float startDelay = 2;
        //        float stopDelay = 4;
        //        StartParticles(startDelay);
        //        StopParticles(stopDelay);
        //    }
    }

    public void StopIdleAnimation()
    {
        //    if (itemName == Wearables.Cigar)
        //    {
        //        // This will trigger the chain of events. Time for fire particles to light and dim should be adjusted
        //        Animator appearAnimator = transform.Find("Zippo").GetComponent<Animator>();
        //        appearAnimator.Rebind();

        //        StopParticles(0);
        //    }
    }
    #endregion

    #region Private Methods
    void StartParticles(float delay)
    {
        StartCoroutine(StartParticlesDelay(delay));
    }

    void StopParticles(float delay)
    {
        StartCoroutine(StopParticlesDelay(delay));
    }
    #endregion

    #region Coroutines
    IEnumerator StartParticlesDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        effectParticles.SetActive(true);
    }

    IEnumerator StopParticlesDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        effectParticles.SetActive(false);
    }
    #endregion
}