using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    float speed = 5;

    public List<GameObject> wearables = new List<GameObject>();

    void Start()
    {
        StartCoroutine(IdleAnimation());    
    }

    #region Public Methods
    public void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    #endregion

    #region Private Methods
    IEnumerator IdleAnimation()
    {
        yield return new WaitForSeconds(2);

        for(int i = 0; i < wearables.Count; i++)
        {
            wearables[i].GetComponent<WearableItem>().RunIdleAnimation();
        }
    }
    #endregion
}
