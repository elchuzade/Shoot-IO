using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;

public class MyCityStatus : MonoBehaviour
{
    Player player;
    [SerializeField] Camera mainCamera;

    List<Platform> platforms = new List<Platform>();

    [SerializeField] GameObject characterPrefab;

    [SerializeField] GameObject cornerPlatformPrefab;
    [SerializeField] GameObject sidePlatformPrefab;
    [SerializeField] GameObject gatePlatformPrefab;

    [SerializeField] GameObject woodTowerPrefab;
    [SerializeField] GameObject stoneTowerPrefab;
    [SerializeField] GameObject metalTowerPrefab;

    [SerializeField] GameObject kremlinPrefab;
    [SerializeField] GameObject whiteHousePrefab;
    [SerializeField] GameObject eiffelTowerPrefab;

    GameObject Me;

    void Start()
    {
        player = FindObjectOfType<Player>();
        player.ResetPlayer();
        player.LoadPlayer();

        // Instantiate a player character and pass all player data to it to instantiate its items, weapon and so on
        InstantiatePlayerCharacter();

        // FAKE DATA
        Platform sidePlatformLeftTopTop = new Platform();

        Platform cornerPlatformLeftTop = new Platform();
        cornerPlatformLeftTop.platformType = PlatformTypes.CornerPlatform;
        cornerPlatformLeftTop.position = new Vector3(-40, 0, 40);

        Tower cornerTowerLeft = new Tower();
        cornerTowerLeft.towerType = TowerTypes.StoneTower;
        cornerTowerLeft.position = cornerPlatformLeftTop.position + new Vector3(-8, 0, 0);

        Tower cornerTowerTop = new Tower();
        cornerTowerTop.towerType = TowerTypes.StoneTower;
        cornerTowerTop.position = cornerPlatformLeftTop.position + new Vector3(0, 0, 8);

        cornerPlatformLeftTop.towers.Add(cornerTowerLeft);
        cornerPlatformLeftTop.towers.Add(cornerTowerTop);

        Building cornerTowerBuilding = new Building();
        cornerTowerBuilding.buildingType = BuildingTypes.Kremlin;
        cornerTowerBuilding.position = cornerPlatformLeftTop.position;

        cornerPlatformLeftTop.buildings.Add(cornerTowerBuilding);



        InstantiatePlatform(cornerPlatformLeftTop);
    }

    void InstantiatePlatform(Platform platform)
    {
        if (platform.platformType == PlatformTypes.CornerPlatform)
        {
            GameObject cornerPlatformInstance = Instantiate(cornerPlatformPrefab, platform.position, Quaternion.Euler(platform.rotation));

            platform.towers.ForEach(tower =>
            {
                if (tower.towerType == TowerTypes.StoneTower)
                {
                    GameObject towerInstance = Instantiate(stoneTowerPrefab, tower.position, Quaternion.Euler(tower.rotation));
                }
            });

            platform.buildings.ForEach(building =>
            {
                if (building.buildingType == BuildingTypes.Kremlin)
                {
                    GameObject buildingInstance = Instantiate(kremlinPrefab, building.position, Quaternion.Euler(building.rotation));
                }
            });
        }
    }

    void InstantiatePlayerCharacter()
    {
        var pos = Random.insideUnitCircle;
        pos = pos.normalized * Random.Range(6.5f, 8);

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
}
