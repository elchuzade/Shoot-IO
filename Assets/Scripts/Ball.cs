using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    float speed = 5;

    #region Public Methods
    public void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    #endregion
}
