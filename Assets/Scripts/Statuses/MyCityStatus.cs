using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCityStatus : MonoBehaviour
{
    Player player;
    [SerializeField] Camera mainCamera;

    [SerializeField] GameObject characterPrefab;

    GameObject Me;

    void Start()
    {
        player = FindObjectOfType<Player>();
        player.ResetPlayer();
        player.LoadPlayer();

        // Instantiate a player character and pass all player data to it to instantiate its items, weapon and so on
        InstantiatePlayerCharacter();
    }

    void Update()
    {

    }

    void InstantiatePlayerCharacter()
    {
        Me = Instantiate(characterPrefab, transform.position, Quaternion.identity);
        Me.transform.Find("Character").GetComponent<Character>().InitializeCharacter(
            player.weapon, player.emoji, player.headItem, player.eyesItem, player.mouthItem);

        // Set main camera to be a child of player so it follows  the player
        mainCamera.transform.SetParent(Me.transform);
        // Set camera to player character so it can be moved out and in when entering and exiting the city
        Me.transform.Find("Character").GetComponent<Character>().playerCamera = mainCamera;
    }
}
