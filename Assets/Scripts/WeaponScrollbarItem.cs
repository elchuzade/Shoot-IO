using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;

public class WeaponScrollbarItem : MonoBehaviour
{
    public Weapons weapon;
    public float damage;
    public float fireRate;

    public void SelectItem()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public void DeselectItem()
    {
        transform.localScale = Vector3.one;
    }
}
