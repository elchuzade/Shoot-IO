using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;

public class ItemInstantiator : MonoBehaviour
{
    [SerializeField] List<GameObject> questItems = new List<GameObject>();
    [SerializeField] List<GameObject> basicItems = new List<GameObject>();
    [SerializeField] List<GameObject> commonItems = new List<GameObject>();
    [SerializeField] List<GameObject> uncommonItems = new List<GameObject>();
    [SerializeField] List<GameObject> rareItems = new List<GameObject>();
    [SerializeField] List<GameObject> epicItems = new List<GameObject>();
    [SerializeField] List<GameObject> uniqueItems = new List<GameObject>();
    [SerializeField] List<GameObject> legendaryItems = new List<GameObject>();
    [SerializeField] List<GameObject> specialItems = new List<GameObject>();
    [SerializeField] List<GameObject> keyItems = new List<GameObject>();
    [SerializeField] GameObject coinItem;
    [SerializeField] GameObject diamondItem;


    public void DropRandomItem(ItemTypes itemType, Vector3 position)
    {
        // Add random shift from center of the enemy
        position += new Vector3(Random.Range(-300, 300) / 100, 0.75f, Random.Range(-300, 300) / 100);

        List<BasicItems> allBasicItems = new List<BasicItems>();
        List<CommonItems> allCommonItems = new List<CommonItems>();
        List<UncommonItems> allUncommonItems = new List<UncommonItems>();
        List<RareItems> allRareItems = new List<RareItems>();
        List<EpicItems> allEpicItems = new List<EpicItems>();
        List<UniqueItems> allUniqueItems = new List<UniqueItems>();
        List<LegendaryItems> allLegendaryItems = new List<LegendaryItems>();
        List<SpecialItems> allSpecialItems = new List<SpecialItems>();

        switch (itemType)
        {
            case ItemTypes.BasicItems:
                // Get Scores of all items and isntantiate that many times those item names to draw from the pool a random item
                for (int i = 0; i < basicItems.Count; i++)
                {
                    for (int j = 0; j < GetBasicItemGearScore(basicItems[i]); j++)
                    {
                        BasicItems basicItem = (BasicItems)System.Enum.Parse(typeof(BasicItems), basicItems[i].name);
                        allBasicItems.Add(basicItem);
                    }
                }
                break;
            case ItemTypes.CommonItems:
                // Get Scores of all items and isntantiate that many times those item names to draw from the pool a random item
                for (int i = 0; i < commonItems.Count; i++)
                {
                    for (int j = 0; j < GetCommonItemGearScore(commonItems[i]); j++)
                    {
                        CommonItems commonItem = (CommonItems)System.Enum.Parse(typeof(CommonItems), commonItems[i].name);
                        allCommonItems.Add(commonItem);
                    }
                }
                break;
            case ItemTypes.UncommonItems:
                // Get Scores of all items and isntantiate that many times those item names to draw from the pool a random item
                for (int i = 0; i < uncommonItems.Count; i++)
                {
                    for (int j = 0; j < GetUncommonItemGearScore(uncommonItems[i]); j++)
                    {
                        UncommonItems uncommonItem = (UncommonItems)System.Enum.Parse(typeof(UncommonItems), uncommonItems[i].name);
                        allUncommonItems.Add(uncommonItem);
                    }
                }
                break;
            case ItemTypes.RareItems:
                // Get Scores of all items and isntantiate that many times those item names to draw from the pool a random item
                for (int i = 0; i < rareItems.Count; i++)
                {
                    for (int j = 0; j < GetRareItemGearScore(rareItems[i]); j++)
                    {
                        RareItems rareItem = (RareItems)System.Enum.Parse(typeof(RareItems), rareItems[i].name);
                        allRareItems.Add(rareItem);
                    }
                }
                break;
            case ItemTypes.EpicItems:
                // Get Scores of all items and isntantiate that many times those item names to draw from the pool a random item
                for (int i = 0; i < epicItems.Count; i++)
                {
                    for (int j = 0; j < GetEpicItemGearScore(epicItems[i]); j++)
                    {
                        EpicItems epicItem = (EpicItems)System.Enum.Parse(typeof(EpicItems), epicItems[i].name);
                        allEpicItems.Add(epicItem);
                    }
                }
                break;
            case ItemTypes.UniqueItems:
                // Get Scores of all items and isntantiate that many times those item names to draw from the pool a random item
                for (int i = 0; i < uniqueItems.Count; i++)
                {
                    for (int j = 0; j < GetUniqueItemGearScore(uniqueItems[i]); j++)
                    {
                        UniqueItems uniqueItem = (UniqueItems)System.Enum.Parse(typeof(UniqueItems), uniqueItems[i].name);
                        allUniqueItems.Add(uniqueItem);
                    }
                }
                break;
            case ItemTypes.LegendaryItems:
                // Get Scores of all items and isntantiate that many times those item names to draw from the pool a random item
                for (int i = 0; i < legendaryItems.Count; i++)
                {
                    for (int j = 0; j < GetLegendaryItemGearScore(legendaryItems[i]); j++)
                    {
                        LegendaryItems legendaryItem = (LegendaryItems)System.Enum.Parse(typeof(LegendaryItems), legendaryItems[i].name);
                        allLegendaryItems.Add(legendaryItem);
                    }
                }
                break;
            case ItemTypes.SpecialItems:
                // Get Scores of all items and isntantiate that many times those item names to draw from the pool a random item
                for (int i = 0; i < specialItems.Count; i++)
                {
                    for (int j = 0; j < GetSpecialItemGearScore(specialItems[i]); j++)
                    {
                        SpecialItems specialItem = (SpecialItems)System.Enum.Parse(typeof(SpecialItems), specialItems[i].name);
                        allSpecialItems.Add(specialItem);
                    }
                }
                break;
        }

        // Now that all data lists are filled up pick a random one
        switch (itemType)
        {
            case ItemTypes.BasicItems:
                BasicItems randomBasicItem = allBasicItems[Random.Range(0, allBasicItems.Count)];
                for (int i = 0; i < basicItems.Count; i++)
                {
                    if (basicItems[i].name == randomBasicItem.ToString())
                    {
                        Instantiate(basicItems[i], position, Quaternion.identity);
                        break;
                    }
                }
                break;
            case ItemTypes.CommonItems:
                CommonItems randomCommonItem = allCommonItems[Random.Range(0, allCommonItems.Count)];
                for (int i = 0; i < commonItems.Count; i++)
                {
                    if (commonItems[i].name == randomCommonItem.ToString())
                    {
                        Instantiate(commonItems[i], position, Quaternion.identity);
                        break;
                    }
                }
                break;
            case ItemTypes.UncommonItems:
                UncommonItems randomUncommonItem = allUncommonItems[Random.Range(0, allUncommonItems.Count)];
                for (int i = 0; i < uncommonItems.Count; i++)
                {
                    if (uncommonItems[i].name == randomUncommonItem.ToString())
                    {
                        Instantiate(uncommonItems[i], position, Quaternion.identity);
                        break;
                    }
                }
                break;
            case ItemTypes.RareItems:
                RareItems randomRareItem = allRareItems[Random.Range(0, allRareItems.Count)];
                for (int i = 0; i < rareItems.Count; i++)
                {
                    if (rareItems[i].name == randomRareItem.ToString())
                    {
                        Instantiate(rareItems[i], position, Quaternion.identity);
                        break;
                    }
                }
                break;
            case ItemTypes.EpicItems:
                EpicItems randomEpicItem = allEpicItems[Random.Range(0, allEpicItems.Count)];
                for (int i = 0; i < epicItems.Count; i++)
                {
                    if (epicItems[i].name == randomEpicItem.ToString())
                    {
                        Instantiate(epicItems[i], position, Quaternion.identity);
                        break;
                    }
                }
                break;
            case ItemTypes.UniqueItems:
                UniqueItems randomUniqueItem = allUniqueItems[Random.Range(0, allUniqueItems.Count)];
                for (int i = 0; i < uniqueItems.Count; i++)
                {
                    if (uniqueItems[i].name == randomUniqueItem.ToString())
                    {
                        Instantiate(uniqueItems[i], position, Quaternion.identity);
                        break;
                    }
                }
                break;
            case ItemTypes.LegendaryItems:
                LegendaryItems randomLegendaryItem = allLegendaryItems[Random.Range(0, allLegendaryItems.Count)];
                for (int i = 0; i < legendaryItems.Count; i++)
                {
                    if (legendaryItems[i].name == randomLegendaryItem.ToString())
                    {
                        Instantiate(legendaryItems[i], position, Quaternion.identity);
                        break;
                    }
                }
                break;
            case ItemTypes.SpecialItems:
                SpecialItems randomSpecialItem = allSpecialItems[Random.Range(0, allSpecialItems.Count)];
                for (int i = 0; i < specialItems.Count; i++)
                {
                    if (specialItems[i].name == randomSpecialItem.ToString())
                    {
                        Instantiate(specialItems[i], position, Quaternion.identity);
                        break;
                    }
                }
                break;
        }
    }

    public void DropKey(KeyTypes keyType, Vector3 position)
    {
        // Add random shift from center of the enemy
        position += new Vector3(Random.Range(-300, 300) / 100, 0.75f, Random.Range(-300, 300) / 100);
        for (int i = 0; i < keyItems.Count; i++)
        {
            if (keyItems[i].name == keyType.ToString())
            {
                Instantiate(keyItems[i], position, Quaternion.identity);
            }
        }
    }

    public void DropCoin(Vector3 position)
    {
        // Add random shift from center of the enemy
        position += new Vector3(Random.Range(-300, 300) / 100, 0.75f, Random.Range(-300, 300) / 100);
        Instantiate(coinItem, position, Quaternion.identity);
    }

    public void DropDiamond(Vector3 position)
    {
        // Add random shift from center of the enemy
        position += new Vector3(Random.Range(-300, 300) / 100, 0.75f, Random.Range(-300, 300) / 100);
        Instantiate(diamondItem, position, Quaternion.identity);
    }

    public void DropQuestItem(QuestItems questItem, Vector3 position)
    {
        // Add random shift from center of the enemy
        position += new Vector3(Random.Range(-300, 300) / 100, 0.75f, Random.Range(-300, 300) / 100);
        for (int i = 0; i < questItems.Count; i++)
        {
            if (questItems[i].name == questItem.ToString())
            {
                Instantiate(questItems[i], position, Quaternion.identity);
            }
        }
    }

    public int GetBasicItemGearScore(GameObject item)
    {
        // Prefab name must match Enum value of the same item
        switch (item.name)
        {
            case "Cigar":
                return 10;
            case "Glock":
                return 20;
            case "USP":
                return 30;
        }
        return 0;
    }

    public int GetCommonItemGearScore(GameObject item)
    {
        // Prefab name must match Enum value of the same item
        switch (item.name)
        {
            case "SteyrAug":
                return 40;
            case "Famas":
                return 50;
            case "AK47":
                return 60;
        }
        return 0;
    }

    public int GetUncommonItemGearScore(GameObject item)
    {
        // Prefab name must match Enum value of the same item
        switch (item.name)
        {
            case "SurgeryMask":
                return 70;
            case "FNP90":
                return 80;
            case "TennisHat":
                return 90;
        }
        return 0;
    }

    public int GetRareItemGearScore(GameObject item)
    {
        // Prefab name must match Enum value of the same item
        switch (item.name)
        {
            case "Binocular":
                return 100;
            case "SnorkleGlasses":
                return 110;
            case "RopeBand":
                return 120;
        }
        return 0;
    }

    public int GetEpicItemGearScore(GameObject item)
    {
        // Prefab name must match Enum value of the same item
        switch (item.name)
        {
            case "Cap":
                return 130;
            case "RussianHat":
                return 140;
            case "Bandana":
                return 150;
        }
        return 0;
    }

    public int GetUniqueItemGearScore(GameObject item)
    {
        // Prefab name must match Enum value of the same item
        switch (item.name)
        {
            case "Mac10":
                return 160;
            case "MilitaryHelmet":
                return 170;
            case "ChefHat":
                return 180;
        }
        return 0;
    }

    public int GetLegendaryItemGearScore(GameObject item)
    {
        // Prefab name must match Enum value of the same item
        switch (item.name)
        {
            case "M4A1":
                return 190;
            case "VikingHelmet":
                return 200;
            case "MinerHelmet":
                return 210;
        }
        return 0;
    }

    public int GetSpecialItemGearScore(GameObject item)
    {
        // Prefab name must match Enum value of the same item
        switch (item.name)
        {
            case "BikerHelmet":
                return 220;
            case "SportsBand":
                return 230;
            case "SnorkleTube":
                return 240;
        }
        return 0;
    }
}
