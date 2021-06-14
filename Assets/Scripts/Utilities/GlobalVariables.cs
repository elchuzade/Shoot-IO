using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
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
        DisappointedDace,
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

    public enum Weapons {
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
        RopeCap,
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

    public enum Wearables {
        Cigar
    };
}
