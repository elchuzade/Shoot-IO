using System.Collections.Generic;
using System;
using static GlobalVariables;

[Serializable]
public class PlayerData
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

    public PlayerData (Player player)
    {
        XP = player.XP;
        HP = player.HP;
        rank = player.rank;
        coins = player.coins;
        diamonds = player.diamonds;

        // STATS
        maxHP = player.maxHP;
        regenHP = player.regenHP;
        damage = player.damage;
        fireRate = player.fireRate;
        stats = player.stats;

        // SLOTS
        weapon = player.weapon;
        emoji = player.emoji;
        headItem = player.headItem;
        eyesItem = player.eyesItem;
        mouthItem = player.mouthItem;

        // INVENTORY
        weaponItems = player.weaponItems;
        headItems = player.headItems;
        eyesItems = player.eyesItems;
        mouthItems = player.mouthItems;
        questItems = player.questItems;
        emojiItems = player.emojiItems;
        potionItems = player.potionItems;

        myVillageName = player.myVillageName;
        towerWeapons = player.towerWeapons;
    }
}
