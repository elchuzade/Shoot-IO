using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GlobalVariables;

public class TowerUpgradeStatus : MonoBehaviour
{
    Player player;

    [SerializeField] FloatingJoystick floatingJoystick;
    [SerializeField] Scrollbar towerScrollbar;
    [SerializeField] Scrollbar weaponScrollbar;
    [SerializeField] List<WeaponScrollbarItem> weaponItems = new List<WeaponScrollbarItem>();
    [SerializeField] List<GameObject> weapons = new List<GameObject>();
    // To set arrow disabled and colors
    int weaponIndex;

    [SerializeField] Transform rightArm;
    // For rotating
    [SerializeField] GameObject tower;
    [SerializeField] GameObject towerArrows;
    [SerializeField] Text damageStat;
    [SerializeField] Text fireRateStat;
    [SerializeField] GameObject eyeButtonDisabled;
    [SerializeField] GameObject weaponLeftArrow;
    [SerializeField] GameObject weaponRightArrow;
    Weapons currentTowerWeaponName;
    [SerializeField] List<GameObject> UIElementsToHide;

    [SerializeField] GameObject towerLeftArrow;
    [SerializeField] GameObject towerRightArrow;
    [SerializeField] List<GameObject> mapTowers = new List<GameObject>();
    // To switch towers on the mini map
    int towerIndex;

    // To remove and create a new weapon
    GameObject weaponInstance;

    // To add up all the rotation. cumulative value of angle
    float towerRotation;

    // To check if it is watching the tower or swiping the list of towers
    bool towerWatchMode = false;

    void Start()
    {
        player = FindObjectOfType<Player>();

        //player.ResetPlayer();
        player.LoadPlayer();

        weaponScrollbar.value = 0;
        weaponScrollbar.value = 0;
        weaponScrollbar.onValueChanged.AddListener(value => SwipeWeaponValue(value));
        towerScrollbar.onValueChanged.AddListener(value => SwipeTowerValue(value));

        // Fake Data
        towerIndex = 0;
        currentTowerWeaponName = player.towerWeapons[towerIndex];

        SelectCurrentWeapon();
        SelectCurrentTower();
    }

    void Update()
    {
        if (towerWatchMode)
        {
            // Joystick is moving rotate tower
            towerRotation -= floatingJoystick.Horizontal * 2;
            tower.transform.localRotation = Quaternion.Euler(0, towerRotation, 0);
            towerArrows.SetActive(true);
            eyeButtonDisabled.SetActive(true);
            ShowAllUIElements(false);
        } else
        {
            // Swipe towers
            towerArrows.SetActive(false);
            eyeButtonDisabled.SetActive(false);
            ShowAllUIElements(true);
        }
    }

    #region Public Methods
    public void SwipeWeaponValue(float value)
    {
        int index = Mathf.Clamp((int)(weapons.Count * value), 0, weapons.Count - 1);
        Weapons newTowerWeaponName = weaponItems[index].weapon;
        if (newTowerWeaponName != currentTowerWeaponName)
        {
            currentTowerWeaponName = weaponItems[index].weapon;
            SelectCurrentWeapon();
        }
    }

    public void SwipeTowerValue(float value)
    {
        towerIndex = Mathf.Clamp((int)(mapTowers.Count * value), 0, mapTowers.Count - 1);
        SelectCurrentTower();
    }

    public void SwitchTowerMode()
    {
        if (towerWatchMode)
        {
            towerWatchMode = false;
            towerArrows.SetActive(false);
        } else
        {
            towerWatchMode = true;
            towerArrows.SetActive(true);
        }
    }

    public void ClickWeaponLeftArrow()
    {
        if (weaponIndex > 0)
        {
            weaponIndex--;
            currentTowerWeaponName = weaponItems[weaponIndex].weapon;
            SelectCurrentWeapon();
        }
    }

    public void ClickWeaponRightArrow()
    {
        if (weaponIndex < weaponItems.Count - 1)
        {
            weaponIndex++;
            currentTowerWeaponName = weaponItems[weaponIndex].weapon;
            SelectCurrentWeapon();
        }
    }

    public void ClickTowerLeftArrow()
    {
        if (towerIndex > 0)
        {
            towerIndex--;
            SelectCurrentTower();
        }
    }

    public void ClickTowerRightArrow()
    {
        if (towerIndex < mapTowers.Count - 1)
        {
            towerIndex++;
            SelectCurrentTower();
        }
    }
    #endregion

    #region Private Methods
    void CheckWeaponArrowColor()
    {
        if (weaponIndex == 0)
        {
            weaponLeftArrow.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        }
        else
        {
            weaponLeftArrow.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

        if (weaponIndex == weaponItems.Count - 1)
        {
            weaponRightArrow.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        }
        else
        {
            weaponRightArrow.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    void CheckTowerArrowColor()
    {
        if (towerIndex == 0)
        {
            towerLeftArrow.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        }
        else
        {
            towerLeftArrow.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

        if (towerIndex == mapTowers.Count - 1)
        {
            towerRightArrow.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        }
        else
        {
            towerRightArrow.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    void ShowAllUIElements(bool showStatus)
    {
        UIElementsToHide.ForEach(el => el.SetActive(showStatus));
    }

    void SelectCurrentWeapon()
    {
        // Find index of current weapon
        for (int i = 0; i < weaponItems.Count; i++)
        {
            if (weaponItems[i].weapon == currentTowerWeaponName)
            {
                // Get the index of current weapon and turn it into coordinates from 0 to 1 for scrollbar
                float scrollbarValue = i / ((float)weaponItems.Count - 1);
                StartCoroutine(SetSelectedWeaponValue(scrollbarValue));
                weaponItems[i].SelectItem();

                damageStat.text = weaponItems[i].damage.ToString();
                fireRateStat.text = weaponItems[i].fireRate.ToString();

                weaponIndex = i;
                CheckWeaponArrowColor();
                InstantiateWeapon(currentTowerWeaponName);

                // Update player Data so towers change their weapon accordingly
                if (player.towerWeapons[towerIndex] != currentTowerWeaponName)
                {
                    Debug.Log("saving");
                    player.towerWeapons[towerIndex] = currentTowerWeaponName;
                    player.SavePlayer();
                }

                break;
            }
        }
        for (int i = 0; i < weaponItems.Count; i++)
        {
            if (weaponItems[i].weapon != currentTowerWeaponName)
            {
                weaponItems[i].DeselectItem();
            }
        }
    }

    void InstantiateWeapon(Weapons currentWeapon)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].name == currentWeapon.ToString())
            {
                if (weaponInstance != null)
                {
                    Destroy(weaponInstance);
                }
                // Instantiate a weapon based on current weapon
                weaponInstance = Instantiate(weapons[i], rightArm.position, rightArm.rotation);
                weaponInstance.transform.SetParent(rightArm);

                break;
            }
        }
    }

    void SelectCurrentTower()
    {
        for (int i = 0; i < mapTowers.Count; i++)
        {
            if (i == towerIndex)
            {
                mapTowers[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                mapTowers[i].GetComponent<Image>().color = new Color32(255, 255, 0, 255);

                // Weapon of a current tower from player data
                Weapons towerWeapon = player.towerWeapons[towerIndex];
                // Find that weapon in the scroll list and set scroll value to that item and set weapon index to that index
                for (int j = 0; j < weaponItems.Count; j++)
                {
                    if (weaponItems[j].weapon == towerWeapon)
                    {
                        // Found the weapon of tower in scroll list
                        weaponIndex = j;
                        currentTowerWeaponName = weaponItems[weaponIndex].weapon;
                        SelectCurrentWeapon();
                    }
                }

                CheckTowerArrowColor();
            } else
            {
                mapTowers[i].transform.localScale = Vector3.one;
                mapTowers[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
    }
    #endregion

    #region Coroutines
    IEnumerator SetSelectedWeaponValue(float value)
    {
        // Need some delay because of scrollbar
        yield return new WaitForSeconds(0.01f);

        weaponScrollbar.value = value;
    }
    #endregion
}
