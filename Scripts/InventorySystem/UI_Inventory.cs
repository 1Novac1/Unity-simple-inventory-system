using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemContainer;
    private Transform itemSlot;
    public PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        itemContainer = transform.Find("ItemContainer");
        itemSlot = Resources.Load<Transform>("Prefabs/ItemSlot");
    }

    public void Setinventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += inventory_OnItemListChanged; //Subscribe to event
        RefreshItemsInInventory();
    }

    private void inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshItemsInInventory();
    }

    public void RefreshItemsInInventory()
    {
        // Delete slot of dropped item
        foreach(Transform child in itemContainer)
        {
            if (child == itemSlot) continue;
            Destroy(child.gameObject);
        }
        //---------------------------

        int _x = 0; // column
        float _itemSlotCellSize = 100f;
        foreach(Item item in inventory.GetItemList()) //Create item slot
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlot, itemContainer).GetComponent<RectTransform>(); // Create an instance of the object
            itemSlotRectTransform.GetComponent<UI_Button>().MouseRightClickFunc = () => // On clicked slot item
            {
               Item _dublicateItem = item.Clone();
               inventory.RemoveItem(item);
               ItemWorld.DropItem(playerController.GetPosition(), _dublicateItem);
            };
            itemSlotRectTransform.anchoredPosition = new Vector2(_x * _itemSlotCellSize, 0); // Set position in UI inventory column
            // Set image for item slot
            Image image = itemSlotRectTransform.Find("spriteOfItem").GetComponent<Image>();
            image.sprite = item.GetSprite();
            //------------------------
            if (item.IsStackable == true)
            {
                // Set count of item
                Text _text = itemSlotRectTransform.Find("countOfItem_Text").GetComponent<Text>();
                if (item.Amount > 1) {
                    _text.gameObject.SetActive(true);
                    _text.text = "" + item.Amount;
                }
                //-------------------
            }
            _x++; // spacing for new slot
        }
    }
}
