using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GlobalVariables;

public class Inventory : MonoBehaviour
{
    Player player;
    // SLOTS
    [SerializeField] GameObject weaponTabSelected;
    [SerializeField] GameObject armorTabSelected;
    [SerializeField] GameObject potionTabSelected;
    [SerializeField] GameObject specialTabSelected;
    [SerializeField] GameObject emojiTabSelected;

    // Prefabs of all items
    [SerializeField] GameObject[] weaponItemPrefabs;
    [SerializeField] GameObject[] headItemPrefabs;
    [SerializeField] GameObject[] eyesItemPrefabs;
    [SerializeField] GameObject[] mouthItemPrefabs;
    [SerializeField] GameObject[] potionItemPrefabs;
    [SerializeField] GameObject[] questItemPrefabs;
    [SerializeField] GameObject[] emojiItemPrefabs;

    [SerializeField] GameObject inventoryItem;
    [SerializeField] Transform inventoryItems;

    [SerializeField] Scrollbar itemsScrollbar;

    [SerializeField] GameObject slotsWindow;
    [SerializeField] GameObject statsWindow;

    [SerializeField] GameObject damageButton;
    [SerializeField] GameObject fireRateButton;
    [SerializeField] GameObject regenHPButton;
    [SerializeField] GameObject maxHPButton;
    [SerializeField] Text damageStat;
    [SerializeField] Text fireRateStat;
    [SerializeField] Text regenHPStat;
    [SerializeField] Text maxHPStat;
    [SerializeField] Text statsCount;

    InventoryItem selectedItem;
    int minItemSlotsCount = 20;
    int maxColumns = 5;

    void Start()
    {
        player = FindObjectOfType<Player>();
        player.LoadPlayer();

        SetStats();

        // Initial Selection
        OpenPotionTab();
    }

    #region Public Methods
    public void AddStat(string statName)
    {
        switch (statName)
        {
            case "Damage":
                player.damage++;
                break;
            case "FireRate":
                player.fireRate++;
                break;
            case "RegenHP":
                player.regenHP++;
                break;
            case "MaxHP":
                player.maxHP++;
                break;
        }
        player.stats--;
        player.SavePlayer();
        SetStats();
    }

    public void SelectItem(InventoryItem itemScript)
    {
        if (selectedItem != null)
        {
            selectedItem.UnselectItem();
        }
        itemScript.SelectItem();

        selectedItem = itemScript;
    }

    public void OpenWeaponTab()
    {
        CloseAllTabs();
        weaponTabSelected.SetActive(true);
        PopulateWeaponItems();
    }

    public void OpenArmorTab()
    {
        CloseAllTabs();
        armorTabSelected.SetActive(true);
        PopulateArmorItems();
    }

    public void OpenPotionTab()
    {
        CloseAllTabs();
        potionTabSelected.SetActive(true);
        PopulatePotionItems();
    }

    public void OpenSpecialTab()
    {
        CloseAllTabs();
        specialTabSelected.SetActive(true);
    }

    public void OpenEmojiTab()
    {
        CloseAllTabs();
        emojiTabSelected.SetActive(true);
        PopulateEmojiItems();
    }

    public void ClickSlotsButton()
    {
        statsWindow.SetActive(false);
        slotsWindow.SetActive(true);
    }

    public void ClickStatsButton()
    {
        statsWindow.SetActive(true);
        slotsWindow.SetActive(false);
    }
    #endregion

    #region Private Methods
    void SetStats()
    {
        if (player.stats > 0)
        {
            // There are some stats to give
            ShowStats();
        }
        else
        {
            HideStats();
        }
        damageStat.text = player.damage.ToString();
        fireRateStat.text = player.fireRate.ToString();
        regenHPStat.text = player.regenHP.ToString();
        maxHPStat.text = player.maxHP.ToString();
        statsCount.text = player.stats.ToString();
    }

    void ShowStats()
    {
        statsCount.transform.parent.gameObject.SetActive(true);
        damageButton.SetActive(true);
        fireRateButton.SetActive(true);
        regenHPButton.SetActive(true);
        maxHPButton.SetActive(true);
    }

    void HideStats()
    {
        statsCount.transform.parent.gameObject.SetActive(false);
        damageButton.SetActive(false);
        fireRateButton.SetActive(false);
        regenHPButton.SetActive(false);
        maxHPButton.SetActive(false);
    }

    void PopulateEmojiItems()
    {
        // Loop through all player emoji items inside it loop through all possible potions,
        // Instantiate a emoji item if name matches
        for (int i = 0; i < player.emojiItems.Count; i++)
        {
            for (int j = 0; j < emojiItemPrefabs.Length; j++)
            {
                if (emojiItemPrefabs[j].name == player.emojiItems[i].ToString())
                {
                    GameObject inventoryItemInstance = Instantiate(inventoryItem, inventoryItems.position, Quaternion.identity);
                    inventoryItemInstance.transform.SetParent(inventoryItems);
                    inventoryItemInstance.transform.localScale = Vector3.one;

                    // Instantiate an icon of item and set it as a child to Item
                    GameObject itemInstance = Instantiate(emojiItemPrefabs[j], inventoryItemInstance.transform.Find("Item").position, Quaternion.identity);
                    itemInstance.transform.SetParent(inventoryItemInstance.transform.Find("Item"));
                    itemInstance.transform.localScale = Vector3.one;

                    // Get Item Rarity Type based on item name
                    ItemTypes itemType = GetItemType(emojiItemPrefabs[j].name);
                    // All potions are basic item types
                    inventoryItemInstance.GetComponent<InventoryItem>().InitializeItemData(itemType);
                    // Set select item function
                    inventoryItemInstance.GetComponent<Button>().onClick.AddListener(() => SelectItem(inventoryItemInstance.GetComponent<InventoryItem>()));
                }
            }
        }
        AddEmptyinventoryItemSlots(player.emojiItems.Count);
    }

    void PopulateArmorItems()
    {
        // Loop through all player head items inside it loop through all possible potions,
        // Instantiate a head item if name matches
        for (int i = 0; i < player.headItems.Count; i++)
        {
            for (int j = 0; j < headItemPrefabs.Length; j++)
            {
                if (headItemPrefabs[j].name == player.headItems[i].ToString())
                {
                    GameObject inventoryItemInstance = Instantiate(inventoryItem, inventoryItems.position, Quaternion.identity);
                    inventoryItemInstance.transform.SetParent(inventoryItems);
                    inventoryItemInstance.transform.localScale = Vector3.one;

                    // Instantiate an icon of item and set it as a child to Item
                    GameObject itemInstance = Instantiate(headItemPrefabs[j], inventoryItemInstance.transform.Find("Item").position, Quaternion.identity);
                    itemInstance.transform.SetParent(inventoryItemInstance.transform.Find("Item"));
                    itemInstance.transform.localScale = Vector3.one;

                    // Get Item Rarity Type based on item name
                    ItemTypes itemType = GetItemType(headItemPrefabs[j].name);
                    // All potions are basic item types
                    inventoryItemInstance.GetComponent<InventoryItem>().InitializeItemData(itemType);
                    // Set select item function
                    inventoryItemInstance.GetComponent<Button>().onClick.AddListener(() => SelectItem(inventoryItemInstance.GetComponent<InventoryItem>()));
                }
            }
        }
        // Loop through all player eyes items inside it loop through all possible potions,
        // Instantiate a eyes item if name matches
        for (int i = 0; i < player.eyesItems.Count; i++)
        {
            for (int j = 0; j < eyesItemPrefabs.Length; j++)
            {
                if (eyesItemPrefabs[j].name == player.eyesItems[i].ToString())
                {
                    GameObject inventoryItemInstance = Instantiate(inventoryItem, inventoryItems.position, Quaternion.identity);
                    inventoryItemInstance.transform.SetParent(inventoryItems);
                    inventoryItemInstance.transform.localScale = Vector3.one;

                    // Instantiate an icon of item and set it as a child to Item
                    GameObject itemInstance = Instantiate(eyesItemPrefabs[j], inventoryItemInstance.transform.Find("Item").position, Quaternion.identity);
                    itemInstance.transform.SetParent(inventoryItemInstance.transform.Find("Item"));
                    itemInstance.transform.localScale = Vector3.one;

                    // Get Item Rarity Type based on item name
                    ItemTypes itemType = GetItemType(eyesItemPrefabs[j].name);
                    // All potions are basic item types
                    inventoryItemInstance.GetComponent<InventoryItem>().InitializeItemData(itemType);
                    // Set select item function
                    inventoryItemInstance.GetComponent<Button>().onClick.AddListener(() => SelectItem(inventoryItemInstance.GetComponent<InventoryItem>()));
                }
            }
        }
        // Loop through all player mouth items inside it loop through all possible potions,
        // Instantiate a mouth item if name matches
        for (int i = 0; i < player.mouthItems.Count; i++)
        {
            for (int j = 0; j < mouthItemPrefabs.Length; j++)
            {
                if (mouthItemPrefabs[j].name == player.mouthItems[i].ToString())
                {
                    GameObject inventoryItemInstance = Instantiate(inventoryItem, inventoryItems.position, Quaternion.identity);
                    inventoryItemInstance.transform.SetParent(inventoryItems);
                    inventoryItemInstance.transform.localScale = Vector3.one;

                    // Instantiate an icon of item and set it as a child to Item
                    GameObject itemInstance = Instantiate(mouthItemPrefabs[j], inventoryItemInstance.transform.Find("Item").position, Quaternion.identity);
                    itemInstance.transform.SetParent(inventoryItemInstance.transform.Find("Item"));
                    itemInstance.transform.localScale = Vector3.one;

                    // Get Item Rarity Type based on item name
                    ItemTypes itemType = GetItemType(mouthItemPrefabs[j].name);
                    // All potions are basic item types
                    inventoryItemInstance.GetComponent<InventoryItem>().InitializeItemData(itemType);
                    // Set select item function
                    inventoryItemInstance.GetComponent<Button>().onClick.AddListener(() => SelectItem(inventoryItemInstance.GetComponent<InventoryItem>()));
                }
            }
        }
        int totalItems = player.headItems.Count + player.eyesItems.Count + player.mouthItems.Count;
        AddEmptyinventoryItemSlots(totalItems);
    }

    void PopulateWeaponItems()
    {
        // Loop through all player weapons inside it loop through all possible potions,
        // Instantiate a weapon item if name matches
        for (int i = 0; i < player.weaponItems.Count; i++)
        {
            for (int j = 0; j < weaponItemPrefabs.Length; j++)
            {
                if (weaponItemPrefabs[j].name == player.weaponItems[i].ToString())
                {
                    GameObject inventoryItemInstance = Instantiate(inventoryItem, inventoryItems.position, Quaternion.identity);
                    inventoryItemInstance.transform.SetParent(inventoryItems);
                    inventoryItemInstance.transform.localScale = Vector3.one;

                    // Instantiate an icon of item and set it as a child to Item
                    GameObject itemInstance = Instantiate(weaponItemPrefabs[j], inventoryItemInstance.transform.Find("Item").position, Quaternion.identity);
                    itemInstance.transform.SetParent(inventoryItemInstance.transform.Find("Item"));
                    itemInstance.transform.localScale = Vector3.one;

                    // Get Item Rarity Type based on item name
                    ItemTypes itemType = GetItemType(weaponItemPrefabs[j].name);
                    // All potions are basic item types
                    inventoryItemInstance.GetComponent<InventoryItem>().InitializeItemData(itemType);
                    // Set select item function
                    inventoryItemInstance.GetComponent<Button>().onClick.AddListener(() => SelectItem(inventoryItemInstance.GetComponent<InventoryItem>()));
                }
            }
        }
        AddEmptyinventoryItemSlots(player.weaponItems.Count);
    }

    void PopulatePotionItems()
    {
        // Loop through all player potions inside it loop through all possible potions,
        // Instantiate a potion item if name matches
        for (int i = 0; i < player.potionItems.Count; i++)
        {
            for (int j = 0; j < potionItemPrefabs.Length; j++)
            {
                if (potionItemPrefabs[j].name == player.potionItems[i].ToString())
                {
                    GameObject inventoryItemInstance = Instantiate(inventoryItem, inventoryItems.position, Quaternion.identity);
                    inventoryItemInstance.transform.SetParent(inventoryItems);
                    inventoryItemInstance.transform.localScale = Vector3.one;

                    // Instantiate an icon of item and set it as a child to Item
                    GameObject itemInstance = Instantiate(potionItemPrefabs[j], inventoryItemInstance.transform.Find("Item").position, Quaternion.identity);
                    itemInstance.transform.SetParent(inventoryItemInstance.transform.Find("Item"));
                    itemInstance.transform.localScale = Vector3.one;

                    // Get Item Rarity Type based on item name
                    ItemTypes itemType = GetItemType(potionItemPrefabs[j].name);
                    // All potions are basic item types
                    inventoryItemInstance.GetComponent<InventoryItem>().InitializeItemData(itemType);
                    // Set select item function
                    inventoryItemInstance.GetComponent<Button>().onClick.AddListener(() => SelectItem(inventoryItemInstance.GetComponent<InventoryItem>()));
                }
            }
        }
        AddEmptyinventoryItemSlots(player.potionItems.Count);
    }

    void AddEmptyinventoryItemSlots(int totalItems)
    {
        int emptyInventoryItemsCount;
        if (totalItems < minItemSlotsCount)
        {
            emptyInventoryItemsCount = minItemSlotsCount - totalItems;
        } else
        {
            emptyInventoryItemsCount = maxColumns - (totalItems % maxColumns);
        }
        for (int i = 0; i < emptyInventoryItemsCount; i++)
        {
            GameObject inventoryItemInstance = Instantiate(inventoryItem, inventoryItems.position, Quaternion.identity);
            inventoryItemInstance.transform.SetParent(inventoryItems);
            inventoryItemInstance.transform.localScale = Vector3.one;
        }
        StartCoroutine(ScrollToTop());
    }

    ItemTypes GetItemType(string itemName)
    {
        switch (itemName)
        {
            // WEAPONS
            case "Famas":
                return ItemTypes.CommonItems;
            case "M4A1":
                return ItemTypes.UncommonItems;

            // HEAD ITEMS
            case "CowboyHat":
                return ItemTypes.UniqueItems;
            case "ChefHat":
                return ItemTypes.SpecialItems;

            // EYES ITEMS
            case "CowboyGlasses":
                return ItemTypes.LegendaryItems;
            case "Binocular":
                return ItemTypes.EpicItems;

            // MOUTH ITEMS
            case "Cigar":
                return ItemTypes.RareItems;
            case "SnorkleTube":
                return ItemTypes.BasicItems;
        }
        return ItemTypes.BasicItems;
    }

    void CloseAllTabs()
    {
        weaponTabSelected.SetActive(false);
        armorTabSelected.SetActive(false);
        potionTabSelected.SetActive(false);
        specialTabSelected.SetActive(false);
        emojiTabSelected.SetActive(false);

        // Remove all instantiated items from the last selected tab
        for (int i = 0; i < inventoryItems.childCount; i++)
        {
            Destroy(inventoryItems.GetChild(i).gameObject);
        }
    }
    #endregion

    #region Coroutines
    IEnumerator ScrollToTop()
    {
        yield return new WaitForSeconds(0.04f);
        itemsScrollbar.value = 0.999f;
    }
    #endregion
}
