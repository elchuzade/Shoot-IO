using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public enum RotateDirection { Clockwise, CounterClockwise }

    public enum ChestColors { None, Red, Gold, Silver }

    public enum Rewards { Diamond, Coin, RedKey, SilverKey, GoldKey }

    public enum Currency { Diamond, Coin }

    public enum Boxes { Lightning, Shield, Bullet, Speed, Diamond, Coin, Question }

    public enum TrapTypes { Bomb, Dynamite, Chainsaw };

    public enum ChestPrizeTypes { Coin, Diamond, Skill, Ball };

    public enum BallTypes { Common, Uncommon, Rare, Legendary, Special };

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

    public enum Wearables {
        Bandana,
        BikerHelmet,
        Binocular,
        Cap,
        Chefhat,
        Cigar,
        CowboyHat,
        EyePatch,
        FootballHelmet,
        MagnifyingGlass,
        MilitaryHelmet,
        MinerHelmet,
        OfficerHat,
        RapCap,
        RopeCap,
        RussianHat,
        SnorkleGlasses,
        SnorkleTube,
        SportsBand,
        SportsGlasses,
        StarGlasses,
        SurgeryMask,
        TennisHat,
        VikingHelmet
    };
}
