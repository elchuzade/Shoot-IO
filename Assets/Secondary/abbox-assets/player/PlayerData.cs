using System.Collections.Generic;
using System;
using static GlobalVariables;

[Serializable]
public class PlayerData
{
    public int coins = 0;
    public Weapons weapon = Weapons.Glock;
    public Emojies emoji = Emojies.SmilingFace;
    public HeadItems headItem = HeadItems.CowboyHat;
    public EyesItems eyesItem = EyesItems.CowboyGlasses;
    public MouthItems mouthItem = MouthItems.Cigar;

    public string myVillageName;
    // Each item in the link represents the weapon for the tower of that index
    public List<Weapons> towerWeapons = new List<Weapons>();

    public PlayerData (Player player)
    {
        coins = player.coins;
        weapon = player.weapon;
        emoji = player.emoji;
        headItem = player.headItem;
        eyesItem = player.eyesItem;
        mouthItem = player.mouthItem;

        myVillageName = player.myVillageName;
        towerWeapons = player.towerWeapons;
    }
}
