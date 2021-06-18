using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GlobalVariables;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] Image itemLight;
    public ItemTypes itemType;

    #region Public Methods
    public void InitializeItemData(ItemTypes _itemType)
    {
        itemType = _itemType;
        SetBackgroundLight();
    }

    public void SelectItem()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1);
    }

    public void UnselectItem()
    {
        transform.localScale = Vector3.one;
    }
    #endregion

    #region Private Methods
    void SetBackgroundLight()
    {
        switch (itemType)
        {
            case ItemTypes.BasicItems:
                itemLight.color = basicColor;
                break;
            case ItemTypes.CommonItems:
                itemLight.color = commonColor;
                break;
            case ItemTypes.UncommonItems:
                itemLight.color = uncommonColor;
                break;
            case ItemTypes.RareItems:
                itemLight.color = rareColor;
                break;
            case ItemTypes.EpicItems:
                itemLight.color = epicColor;
                break;
            case ItemTypes.UniqueItems:
                itemLight.color = uniqueColor;
                break;
            case ItemTypes.LegendaryItems:
                itemLight.color = legendaryColor;
                break;
            case ItemTypes.SpecialItems:
                itemLight.color = specialColor;
                break;
        }
    }
    #endregion
}
