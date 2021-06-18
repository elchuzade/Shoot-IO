using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;

public class Player : MonoBehaviour
{
    public int XP = 0;
    public int HP = 100;
    public int coins = 0;
    public int diamonds = 0;
    public PlayerRank rank = PlayerRank.Rank0;

    // STATS
    public int maxHP = 100;
    public float regenHP = 1;
    public int damage = 10;
    public int fireRate = 5;
    public int stats = 0;

    // SLOTS
    public Weapons weapon = Weapons.Glock;
    public Emojies emoji = Emojies.SmilingFace;
    public HeadItems headItem = HeadItems.CowboyHat;
    public EyesItems eyesItem = EyesItems.CowboyGlasses;
    public MouthItems mouthItem = MouthItems.Cigar;

    // INVENTORY
    public List<Weapons> weaponItems = new List<Weapons>();
    public List<HeadItems> headItems = new List<HeadItems>();
    public List<EyesItems> eyesItems = new List<EyesItems>();
    public List<MouthItems> mouthItems = new List<MouthItems>();
    public List<QuestItems> questItems = new List<QuestItems>();
    public List<Emojies> emojiItems = new List<Emojies>();
    public List<Potions> potionItems = new List<Potions>();

    public string myVillageName;
    // Each item in the link represents the weapon for the tower of that index
    public List<Weapons> towerWeapons = new List<Weapons>();

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
        XP = 20;
        HP = 100;
        rank = PlayerRank.Rank0;
        coins = 0;
        diamonds = 0;

        // STATS
        maxHP = 1000;
        fireRate = 5; // Bullets per second
        regenHP = 1;
        damage = 10;
        stats = 2;

        // SLOTS
        weapon = Weapons.Mac10;
        emoji = Emojies.AngryFace;
        headItem = HeadItems.FootballHelmet;
        eyesItem = EyesItems.CowboyGlasses;
        mouthItem = MouthItems.Cigar;

        // INVENTORY
        weaponItems = new List<Weapons>() { Weapons.Famas, Weapons.M4A1 };
        headItems = new List<HeadItems>() {
            HeadItems.CowboyHat,
            HeadItems.ChefHat,
            HeadItems.ChefHat,
            HeadItems.RopeBand,
            HeadItems.OfficerHat,
            HeadItems.OfficerHat,
            HeadItems.SportsBand,
            HeadItems.TennisHat,
            HeadItems.VikingHelmet,
            HeadItems.VikingHelmet,
            HeadItems.MinerHelmet,
            HeadItems.BikerHelmet,
            HeadItems.RussianHat,
            HeadItems.RapCap,
            HeadItems.FootballHelmet,
            HeadItems.FootballHelmet,
        };
        eyesItems = new List<EyesItems>() {
            EyesItems.Binocular,
            EyesItems.CowboyGlasses,
            EyesItems.StarGlasses,
            EyesItems.SportsGlasses,
            EyesItems.SnorkleGlasses,
            EyesItems.SnorkleGlasses
        };
        mouthItems = new List<MouthItems>() {
            MouthItems.Cigar,
            MouthItems.Cigar,
            MouthItems.SnorkleTube,
            MouthItems.SnorkleTube,
            MouthItems.SnorkleTube
        };
        questItems = new List<QuestItems>() { QuestItems.BearClaw, QuestItems.DragonTooth };
        emojiItems = new List<Emojies>() { Emojies.AngryFace, Emojies.DisappointedFace };
        potionItems = new List<Potions>() {
            Potions.XPPotion,
            Potions.DamagePotion,
            Potions.DamagePotion,
            Potions.DamagePotion,
            Potions.SpeedPotion,
            Potions.HPPotion,
            Potions.HPPotion
        };

        towerWeapons = new List<Weapons>() {
            Weapons.Famas, Weapons.Famas,
            Weapons.M4A1, Weapons.M4A1, Weapons.M4A1,
            Weapons.AK47, Weapons.AK47, Weapons.AK47,
            Weapons.SteyrAug, Weapons.SteyrAug, Weapons.SteyrAug,
            Weapons.Famas,
            Weapons.FNP90, Weapons.FNP90, Weapons.FNP90, Weapons.FNP90
        };
        myVillageName = "My Village";

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

        XP = data.XP;
        HP = data.HP;
        rank = data.rank;
        coins = data.coins;
        diamonds = data.diamonds;

        // STATS
        maxHP = data.maxHP;
        fireRate = data.fireRate;
        damage = data.damage;
        regenHP = data.regenHP;
        stats = data.stats;

        // SLOTS
        weapon = data.weapon;
        emoji = data.emoji;
        headItem = data.headItem;
        eyesItem = data.eyesItem;
        mouthItem = data.mouthItem;

        // INVENTORY
        weaponItems = data.weaponItems;
        headItems = data.headItems;
        eyesItems = data.eyesItems;
        mouthItems = data.mouthItems;
        questItems = data.questItems;
        emojiItems = data.emojiItems;
        potionItems = data.potionItems;

        myVillageName = data.myVillageName;
        towerWeapons = data.towerWeapons;
    }
}
