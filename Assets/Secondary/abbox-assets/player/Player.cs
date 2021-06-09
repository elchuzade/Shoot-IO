using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;

public class Player : MonoBehaviour
{
    public int coins = 0;
    public Weapons weapon = Weapons.Glock;
    public Emojies emoji = Emojies.SmilingFace;
    public HeadItems headItem = HeadItems.CowboyHat;
    public EyesItems eyesItem = EyesItems.CowboyGlasses;
    public MouthItems mouthItem = MouthItems.Cigar;

    public List<Platform> platforms = new List<Platform>();

    void Awake()
    {
        transform.SetParent(transform.parent.parent);
        // Singleton
        int instances = FindObjectsOfType<Player>().Length;
        if (instances > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void ResetPlayer()
    {
        coins = 0;
        weapon = Weapons.FNP90;
        emoji = Emojies.AngryFace;
        headItem = HeadItems.FootballHelmet;
        //eyesItem = EyesItems.CowboyGlasses;
        //mouthItem = MouthItems.Cigar;

        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data == null)
        {
            ResetPlayer();
            data = SaveSystem.LoadPlayer();
        }

        coins = data.coins;
        weapon = data.weapon;
        emoji = data.emoji;
        headItem = data.headItem;
        eyesItem = data.eyesItem;
        mouthItem = data.mouthItem;
    }
}
