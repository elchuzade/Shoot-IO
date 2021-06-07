using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public List<GameObject> wearables = new List<GameObject>();

    #region Public Methods
    public void RunIdleAnimation()
    {
        for (int i = 0; i < wearables.Count; i++)
        {
            wearables[i].GetComponent<WearableItem>().RunIdleAnimation();
        }
    }

    public void StopIdleAnimation()
    {
        for (int i = 0; i < wearables.Count; i++)
        {
            wearables[i].GetComponent<WearableItem>().StopIdleAnimation();
        }
    }
    #endregion

    #region Private Methods
    #endregion
}
