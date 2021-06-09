using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public class CityBlock
    {
        public Vector3 position;
    }

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

    public class Building {
        public Vector3 position;
        public Vector3 rotation;
        public BuildingTypes buildingType;
    };

    public class Gate {
        public Vector3 position;
        public Vector3 rotation;
        public GateTypes gateType;
    };

    public class Tower
    {
        public Vector3 position;
        public Vector3 rotation;
        public TowerTypes towerType;
    };

    public class Wall
    {
        public Vector3 position;
        public Vector3 rotation;
        public WallTypes wallType;
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
