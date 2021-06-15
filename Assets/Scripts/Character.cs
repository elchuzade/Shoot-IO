using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;

public class Character : MonoBehaviour
{
    public Camera playerCamera;
    // Not to keep zooming in or out nonstop, do it only once
    public bool cameraInCity = false;

    // This is to check whether idle animations need to run
    public bool idle;
    [SerializeField] Rigidbody rb;

    // These are to determine if there is an idle animation, then to run it
    public HeadItem headItemScript;
    public EyesItem eyesItemScript;
    public MouthItem mouthItemScript;
    // This is to run idle animation as well as in city moving moving up state
    public Weapon weaponScript;

    // When building something in city hide weapon and show blueprint
    public GameObject blueprint;

    public Transform body;
    public Transform sight;
    public Transform rightArm;
    // To move the weapon up when inside a city and down when outside
    public Transform rightArmUp;

    // These will be fetched from Emoji children
    Transform head;
    Transform eyes;
    Transform mouth;

    // These are to instantiate correct items on the character
    [SerializeField] GameObject[] allEmojies;
    [SerializeField] GameObject[] allWeapons;
    [SerializeField] GameObject[] allHeadItems;
    [SerializeField] GameObject[] allEyesItems;
    [SerializeField] GameObject[] allMouthItems;

    // This is to keep track of all city blocks a player is on currently.
    // For transitions between blocks to maintain the inCity status
    List<GameObject> cityPlatforms = new List<GameObject>();

    // This is to have speed multipliers as rank increases or as weapon changes or as skill upgrades
    float baseSpeed = 24f;

    #region Public Methods
    public void EnterCity(GameObject cityPlatform)
    {
        // Check from all platforms that are added to the list as detected under you
        // If current platform exists then ignore the function, else add this platform to the list
        bool foundPlatform = false;

        for (int i = 0; i < cityPlatforms.Count; i++)
        {
            if (cityPlatforms[i].GetHashCode() == cityPlatform.GetHashCode())
            {
                foundPlatform = true;
            }
        }

        if (!foundPlatform)
        {
            cityPlatforms.Add(cityPlatform);

            // Only if there is at lease one plaltform detected under the player and the camera is not zoomed out
            // Perform the camera zoom out and weapon move to inCity position
            if (cityPlatforms.Count > 0 && !cameraInCity)
            {
                weaponScript.MoveWeapon(rightArmUp);
                //playerCamera.transform.position += new Vector3(0, 5, -5);
                cameraInCity = true;
            }
        }

    }

    public void ExitCity(GameObject cityPlatform)
    {
        // Check from all platforms that are added to the list as detected under you
        // If current platform exists then remove it, else ignore the platform
        GameObject foundPlatform = null;

        for (int i = 0; i < cityPlatforms.Count; i++)
        {
            if (cityPlatforms[i].GetHashCode() == cityPlatform.GetHashCode())
            {
                foundPlatform = cityPlatforms[i];
            }
        }

        if (foundPlatform != null)
        {
            cityPlatforms.Remove(foundPlatform);

            // There is a time between platforms when player is on two adjacent platforms simultaneousely
            // Do not move the weapon down and do not change the camera zoom at that moment
            if (cityPlatforms.Count == 0 && cameraInCity)
            {
                weaponScript.MoveWeapon(rightArm);
                cameraInCity = false;
            }
        }
    }

    public void Move(Vector3 direction)
    {
        //float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        rb.velocity = direction.normalized * baseSpeed;
    }

    public void Turn(Vector3 direction)
    {
        // Follow mouse direction
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

        if (angle != 0)
        {
            // Joystick is moving
            transform.localRotation = Quaternion.Euler(0, 90 - angle, 0);
        }
    }

    public void InitializeCharacter(
        Weapons weapon, Emojies emoji, HeadItems headItem, EyesItems eyesItem, MouthItems mouthItem)
    {
        // Instantiate item based on its name. Keep GlobalVariables item name and actual name consistent
        for (int i = 0; i < allEmojies.Length; i++)
        {
            if (allEmojies[i].name == emoji.ToString())
            {
                GameObject emojiPrefab;
                emojiPrefab = allEmojies[i];
                GameObject emojiInstance = Instantiate(emojiPrefab, body.position, Quaternion.identity);
                emojiInstance.transform.SetParent(body);
                // Get head, eyes and mouth coordinates of the emoji
                head = emojiInstance.transform.Find("Head");
                eyes = emojiInstance.transform.Find("Eyes");
                mouth = emojiInstance.transform.Find("Mouth");

                break;
            }
        }
        for (int i = 0; i < allWeapons.Length; i++)
        {
            if (allWeapons[i].name == weapon.ToString())
            {
                GameObject weaponPrefab;
                weaponPrefab = allWeapons[i];
                GameObject weaponInstance = Instantiate(weaponPrefab, rightArm.position, Quaternion.identity);
                weaponInstance.transform.SetParent(rightArm);
                weaponScript = weaponInstance.GetComponent<Weapon>();

                break;
            }
        }
        for (int i = 0; i < allHeadItems.Length; i++)
        {
            if (allHeadItems[i].name == headItem.ToString())
            {
                GameObject headItemPrefab;
                headItemPrefab = allHeadItems[i];
                GameObject headItemInstance = Instantiate(headItemPrefab, head.position, Quaternion.identity);
                headItemInstance.transform.SetParent(head);
                headItemScript = headItemInstance.GetComponent<HeadItem>();

                break;
            }
        }
        for (int i = 0; i < allEyesItems.Length; i++)
        {
            if (allEyesItems[i].name == eyesItem.ToString())
            {
                GameObject eyesItemPrefab;
                eyesItemPrefab = allEyesItems[i];
                GameObject eyesItemInstance = Instantiate(eyesItemPrefab, eyes.position, Quaternion.identity);
                eyesItemInstance.transform.SetParent(eyes);
                eyesItemScript = eyesItemInstance.GetComponent<EyesItem>();

                break;
            }
        }
        for (int i = 0; i < allMouthItems.Length; i++)
        {
            if (allMouthItems[i].name == mouthItem.ToString())
            {
                GameObject mouthItemPrefab;
                mouthItemPrefab = allMouthItems[i];
                GameObject mouthItemInstance = Instantiate(mouthItemPrefab, mouth.position, Quaternion.identity);
                mouthItemInstance.transform.SetParent(mouth);
                mouthItemScript = mouthItemInstance.GetComponent<MouthItem>();

                break;
            }
        }
    }
    #endregion
}