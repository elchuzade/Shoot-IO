using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;

public class MyVillageStatus : MonoBehaviour
{
    Player player;
    [SerializeField] Camera mainCamera;

    [SerializeField] GameObject characterPrefab;
    GameObject Me;

    // All towers on the map
    [SerializeField] List<GameObject> towers = new List<GameObject>();

    [SerializeField] List<GameObject> weaponPrefabs = new List<GameObject>();

    void Start()
    {
        player = FindObjectOfType<Player>();
        //player.ResetPlayer();
        player.LoadPlayer();

        // Instantiate a player character and pass all player data to it to instantiate its items, weapon and so on
        InstantiatePlayerCharacter();

        InstantiateTowerWeapons();
    }


    #region Private Methods
    void InstantiatePlayerCharacter()
    {
        Vector2 pos = Random.insideUnitCircle;
        // 6.5 and 8 define the inner and outer circle of haimdall house
        pos = pos.normalized * Random.Range(6.5f, 8);

        // 0.75 is half of the height of an emoji
        Vector3 randomPosition = new Vector3(pos.x, 0.75f, pos.y);

        Me = Instantiate(characterPrefab, transform.position, Quaternion.identity);
        Me.transform.Find("Character").GetComponent<Character>().InitializeCharacter(
            player.weapon, player.emoji, player.headItem, player.eyesItem, player.mouthItem);

        // Set main camera to be a child of player so it follows  the player
        mainCamera.transform.SetParent(Me.transform);
        // Set camera to player character so it can be moved out and in when entering and exiting the city
        Me.transform.Find("Character").GetComponent<Character>().playerCamera = mainCamera;

        // Place player in a random coordinate around the disk of Haimdall
        Me.transform.position = randomPosition;
    }

    void InstantiateTowerWeapons()
    {
        // Loop through all towers keeping the index in mind since it matches player data towerWeapons index
        for (int i = 0; i < towers.Count; i++)
        {
            // Loop through all weapon prefabs to find the correct one for current tower
            for (int j = 0; j < weaponPrefabs.Count; j++)
            {
                if (player.towerWeapons[i] == weaponPrefabs[j].GetComponent<Weapon>().weaponName)
                {
                    towers[i].GetComponent<Tower>().InstantiateTowerWeapon(weaponPrefabs[j]);
                }
            }
        }
    }
    #endregion

    #region Public Methods
    #endregion
}
