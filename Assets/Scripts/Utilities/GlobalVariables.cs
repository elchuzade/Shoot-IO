using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    // Change prefab colors too from materials for them
    public static Color32 basicColor = new Color32(183, 183, 183, 255);
    public static Color32 commonColor = new Color32(176, 29, 32, 255);
    public static Color32 uncommonColor = new Color32(50, 255, 10, 255);
    public static Color32 rareColor = new Color32(105, 50, 211, 255);
    public static Color32 epicColor = new Color32(107, 100, 5, 255);
    public static Color32 uniqueColor = new Color32(60, 5, 255, 255);
    public static Color32 legendaryColor = new Color32(100, 175, 150, 255);
    public static Color32 specialColor = new Color32(100, 5, 50, 255);

    public enum StatTypes { Damage, FireRate, RegenHP, MaxHP };

    public enum MobMovementTypes { Patrol, Idle, Wander };

    public enum RotateDirection { Clockwise, CounterClockwise }

    public enum ChestColors { None, Red, Gold, Silver }

    public enum Rewards { Diamond, Coin, RedKey, SilverKey, GoldKey }

    public enum Currency { Diamond, Coin }

    public enum Boxes { Lightning, Shield, Bullet, Speed, Diamond, Coin, Question }

    public enum TrapTypes { Bomb, Dynamite, Chainsaw };

    public enum ChestPrizeTypes { Coin, Diamond, Skill, Ball };

    public enum BallTypes { Common, Uncommon, Rare, Legendary, Special };

    public enum PlatformTypes { CornerPlatform, GatePlatform, SidePlatform };
    public enum BuildingTypes { WhiteHouse, EiffelTower, Kremlin };
    public enum TowerTypes { WoodTower, StoneTower, MetalTower };
    public enum WallTypes { WoodWall, StoneWall, MetalWall };
    public enum GateTypes { WoodGate, StoneGate, MetalGate };

    public enum InventoryTabs
    {
        WeaponTab,
        ArmorTab,
        PotionTab,
        SpecialTab,
        EmojiTab
    };

    public enum Potions
    {
        XPPotion,
        HPPotion,
        SpeedPotion,
        DamagePotion
    };

    public enum KeyTypes
    {
        BasicKey,
        CommonKey,
        UncommonKey,
        RareKey,
        EpicKey,
        UniqueKey,
        LegendaryKey,
        SpecialKey,
    };

    public enum QuestItems
    {
        DragonTooth,
        BearClaw,
        ResurrectionPotion,
        TreasureMap,
        MagicSword
    };

    public enum BasicItems
    {
        Cigar,
        Glock,
        USP
    };

    public enum CommonItems
    {
        SteyrAug,
        Famas,
        AK47
    };
        
    public enum UncommonItems
    {
        SurgeryMask,
        FNP90,
        TennisHat
    };

    public enum RareItems
    {
        Binocular,
        SnorkleGlasses,
        RopeBand
    };

    public enum EpicItems
    {
        Cap,
        RussianHat,
        Bandana
    };

    public enum UniqueItems
    {
        Mac10,
        MilitaryHelmet,
        ChefHat
    };

    public enum LegendaryItems
    {
        M4A1,
        VikingHelmet,
        MinerHelmet
    };

    public enum SpecialItems
    {
        BikerHelmet,
        SportsBand,
        SnorkleTube
    };

    public enum ItemTypes
    {
        BasicItems,
        CommonItems,
        UncommonItems,
        RareItems,
        EpicItems,
        UniqueItems,
        LegendaryItems,
        SpecialItems
    };

    public enum PlayerRank
    {
        Rank0,
        Rank1,
        Rank2,
        Rank3,
        Rank4,
        Rank5,
        Rank6,
        Rank7,
        Rank8,
        Rank9,
        Rank10,
        Rank11,
        Rank12,
        Rank13,
        Rank14,
        Rank15,
        Rank16,
        Rank17,
        Rank18,
        Rank19,
        Rank20,
        Rank21,
        Rank22,
        Rank23,
        Rank24,
        Rank25,
        Rank26,
        Rank27,
        Rank28,
        Rank29,
        Rank30,
        Rank31,
        Rank32,
        Rank33,
        Rank34,
        Rank35,
        Rank36,
        Rank37,
        Rank38,
        Rank39,
        Rank40,
        Rank41,
        Rank42,
        Rank43,
        Rank44,
        Rank45,
        Rank46,
        Rank47,
        Rank48,
        Rank49,
        Rank50,
        Rank51,
        Rank52,
        Rank53,
        Rank54,
        Rank55     
    };

    public enum Emojies
    {
        AngryFace,
        DisappointedFace,
        FaceWithRaisedEyebrow,
        FaceWithTearsOfJoy,
        GrinningFace,
        GrinningFaceWithSmilingEyes,
        GrinningFaceWithSweat,
        GrinningSquintingFace,
        PensiveFace,
        RelievedFace,
        SlightlySmilingFace,
        SmilingFaceWIthSmilingEyes,
        SmilingFaceWithTears,
        SmilingFace,
        SmirkingFace,
        UnamusedFace,
        WinkingFace,
        WoozyFace
    };

    public enum Weapons
    {
        Glock,
        DesertEagle,
        Revolver,
        AK47,
        Famas,
        FNP90,
        M3Super90,
        M4A1,
        Mac10,
        SteyrAug,
        USP,
        Rifle,
        Sniper,
        EpicSniper
    };

    public enum HeadItems
    {
        BikerHelmet,
        Cap,
        ChefHat,
        CowboyHat,
        FootballHelmet,
        MilitaryHelmet,
        MinerHelmet,
        OfficerHat,
        RapCap,
        RopeBand,
        RussianHat,
        SportsBand,
        TennisHat,
        VikingHelmet
    };

    public enum EyesItems
    {
        Binocular,
        EyePatch,
        MagnifyingGlass,
        SnorkleGlasses,
        SportsGlasses,
        StarGlasses,
        CowboyGlasses
    };

    public enum MouthItems
    {
        Bandana,
        Cigar,
        SnorkleTube,
        SurgeryMask,
    };
}
