using UnityEngine;

public class Tower : MonoBehaviour
{
    // If it is my village then show upgrade window as approaching
    // Else it can be enemy village or tower upgrade scene
    public bool myVillage;
    // To access from myVillage to decide which weapon to give
    public int towerIndex;
    [SerializeField] Transform rightArm;

    void Start()
    {

    }

    void Update()
    {
        
    }

    #region Private Methods

    #endregion

    #region Public Methods
    public void InstantiateTowerWeapon(GameObject weapon)
    {
        GameObject weaponInstance = Instantiate(weapon, rightArm.position, rightArm.rotation);
        weaponInstance.transform.SetParent(transform);

    }
    #endregion
}
